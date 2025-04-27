using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MachineManager : IMachineService
    {
        private readonly IMachineDal _machineDal;

        public MachineManager(IMachineDal machineDal)
        {
            _machineDal = machineDal;
        }

        public IResult Add(Machine machine)
        {
            _machineDal.Add(machine);
            return new SuccessResult("Makine başarıyla eklendi.");
        }

        public IResult Delete(Machine machine)
        {
            _machineDal.Delete(machine);
            return new SuccessResult("Makine başarıyla silindi.");
        }

        public IDataResult<List<Machine>> GetAll()
        {
            var machines = _machineDal.GetAll();
            return new SuccessDataResult<List<Machine>>(machines);
        }

        public IDataResult<Machine> GetById(int id)
        {
            var machine = _machineDal.Get(m => m.Id == id);
            return new SuccessDataResult<Machine>(machine);
        }

        public IResult Update(Machine machine)
        {
            _machineDal.Update(machine);
            return new SuccessResult("Makine başarıyla güncellendi.");
        }
    }
}
