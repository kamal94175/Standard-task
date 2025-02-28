﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Talent.Common.Aws;
using Talent.Common.Contracts;

namespace Talent.Common.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;
        private readonly string _tempFolder;
        private IAwsService _awsService;

        public FileService(IHostingEnvironment environment, 
            IAwsService awsService)
        {
            _environment = environment;
            _tempFolder = "images\\";
            _awsService = awsService;
        }

        public async Task<string> GetFileURL(string id, FileType type)
        {
            String url = await _awsService.GetStaticUrl(id, "kamal.site");
            return url;
        }

        public async Task<string> SaveFile(string fileName, IFormFile file, FileType type)
        {
            if (await _awsService.PutFileToS3(fileName, file.OpenReadStream(), "kamal.site", true))
            {
                return fileName;
            }
            else
            {
                return null;
            }
            
                // TODO return null.
            //var newFileName = await _awsService.PutFileToS3(fileName, file.OpenReadStream(), "kamal.site", true);
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteFile(string id, FileType type)
        {
           
               if(await _awsService.RemoveFileFromS3(id, "kamal.site"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Document Save Methods

        private async Task<string> SaveFileGeneral(IFormFile file, string bucket, string folder, bool isPublic)
        {
            //Your code here;
            throw new NotImplementedException();
        }
        
        private async Task<bool> DeleteFileGeneral(string id, string bucket)
        {
            //Your code here;
            throw new NotImplementedException();
        }
        #endregion
    }
}
