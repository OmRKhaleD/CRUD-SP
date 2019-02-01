using System.Collections.Generic;

namespace CRUD_SP.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Init();
        }
        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public string EventCommand { get; set; }
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string EventArgument { get; set; }

        protected virtual void ListMode()
        {
            IsValid = true;
            Mode = "List";
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        protected virtual void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
            Mode = "Add";
        }

        protected virtual void EditMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
            Mode = "Edit";
        }


        protected virtual void Init()
        {
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();
            ListMode();
            EventCommand = "list";
        }

        protected virtual void Get() { }

        protected virtual void ResetSearch() { }

        protected virtual void Add() { AddMode(); }

        protected virtual void Edit() { EditMode(); }

        protected virtual void Delete() { ListMode(); }

        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }
            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;
                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                default:
                    break;
            }
        }
    }
}