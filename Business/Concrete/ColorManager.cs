using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Added(Color color)
        {
            _colorDal.Added(color);
            return new SuccessResult(Messages.AddColorMessage);
        }

       

        public IResult Deleted(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
          var result =  _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetById(int colorId) // bunu kullanmam muhtemelen yada bilmem ki
        {
            var result = _colorDal.GetAll(c=>c.ColorId==colorId);
            return new SuccessDataResult<Color>();
        }

      
    }
}
