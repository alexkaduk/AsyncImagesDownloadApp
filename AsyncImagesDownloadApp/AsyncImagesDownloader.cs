using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AsyncImagesDownloadApp
{
    class AsyncImagesDownloader
    {
        IEnumerable<Data> data = null;
        public static CancellationTokenSource cts;
        PopupWindow popup;

        public AsyncImagesDownloader(IEnumerable<Data> data)
        {
            this.data = data;
            popup = new PopupWindow();
        }

        public async Task<IEnumerable<Data>> GetDownloadedData()
        {
            cts = new CancellationTokenSource();

            try
            {
                await AsyncImagesAccess(cts.Token);

                popup.prgProgress.SetValue(ProgressBar.ValueProperty, 0.0);
                popup.Close();
                return this.data;
            }

            catch (Exception)
            {
                throw new Exception();
            }

            finally
            {
                cts = null;
                popup.Close();
            }
        }
        async Task AsyncImagesAccess(CancellationToken ct)
        {
            var client = new HttpClient();

            IEnumerable<Task<Data>> downloadTasksQuery =
                from d in data select ProcessUrl(d, client, ct);

            List<Task<Data>> downloadTasks = downloadTasksQuery.ToList();

            var currentDir = Environment.CurrentDirectory;

            if (!Directory.Exists(currentDir + @"\img"))
            {
                Directory.CreateDirectory(currentDir + @"\img");
            }
            
            popup.Show();

            int num = 0;
            var tasksCount = downloadTasks.Count;

            // process tasks
            while (downloadTasks.Count > 0)
            {
                Task<Data> firstFinishedTask = await Task.WhenAny(downloadTasks);

                num++;
                popup.prgProgress.SetValue(ProgressBar.ValueProperty, (double)num / tasksCount);
                popup.txtProgress.Text = "Download #" + num.ToString() + " starts; current task status: '" + firstFinishedTask.Status + "' (there are " + tasksCount.ToString() + " tasks)";

                downloadTasks.Remove(firstFinishedTask);

                foreach (var d in data)
                {
                    if (d.Id == firstFinishedTask.Result.Id)
                    {
                        d.DownLoadedImageContent = firstFinishedTask.Result.DownLoadedImageContent;
                        d.DownloadedImagePath = Path.Combine(currentDir, "img", firstFinishedTask.Result.ImageComponentName.ToString() + ".png");

                        File.WriteAllBytes(d.DownloadedImagePath, d.DownLoadedImageContent);
                    }
                }
            }
        }

        async Task<Data> ProcessUrl(Data data, HttpClient client, CancellationToken ct)
        {
            HttpResponseMessage response = await client.GetAsync(data.ImageUrl, ct);

            var task = response.Content.ReadAsByteArrayAsync();

            data.DownLoadedImageContent = await task;

            return data;
        }
    }
}
