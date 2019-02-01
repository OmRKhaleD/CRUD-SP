using System;
using System.Collections.Generic;

namespace CRUD_SP.Models
{
    public class TrainingProductViewModel : BaseViewModel
    {
        public TrainingProductViewModel() : base()
        {
        }

        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct Entity { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        TrainingProductManager mg { get; set; }

        protected override void Init()
        {
            base.Init();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            mg = new TrainingProductManager();
        }

        

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        protected override void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct()
            {
                IntroductionDate = DateTime.Now,
                Url = "http://",
                Price = 0
            };
            base.Add();
        }

        protected override void Edit()
        {
            mg = new TrainingProductManager();
            Entity = mg.Get(Convert.ToInt32(EventArgument));
            base.Edit();
        }

        protected override void Save()
        {
            mg = new TrainingProductManager();
            if (Mode == "Add")
            {
                mg.Insert(Entity);
            }
            else
            {
                mg.Update(Entity);
            }
            ValidationErrors = mg.ValidationErrors;
            base.Save();
        }

      protected  override void Get()
        {
            mg = new TrainingProductManager();
            Products = mg.Get(SearchEntity);
        }

        protected override void Delete()
        {
            mg = new TrainingProductManager();
            Entity = mg.Get(Convert.ToInt32(EventArgument));
            mg.Delete (Entity);
            Get();
            base.Delete();
        }
    }
}