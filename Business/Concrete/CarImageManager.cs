using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;
        public CarImageManager(ICarImageDal carImageDal,IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }


        public IResult Add(IFormFile file, CarImage carImage)
        {
            BusinessRules.Run(CheckImageOfCarLimit(carImage.CarId));
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.ImagePath);
            carImage.Date = DateTime.Now;
            // carImage.CarId = carId  --> araba ekleme işleminde uygulanabilir.
            _carImageDal.Added(carImage);
            return new SuccessResult();

        }

        
        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            
           var result =  BusinessRules.Run(CheckCarImage(carId));
            if(result != null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
              
            }
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(carImages);
        }


        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            var carImage = _carImageDal.Get(c => c.Id == imageId);
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.ImagePath + carImage.ImagePath, PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
 /*******************************************************************************************************************************************************/       
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result >0 )
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckImageOfCarLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {


            var carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

    }
}
