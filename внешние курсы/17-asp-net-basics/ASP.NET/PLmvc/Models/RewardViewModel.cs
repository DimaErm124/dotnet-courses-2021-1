using HandlerValue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PLmvc.Models
{
    public class RewardViewModel
    {
        private string _title;

        private string _description;

        public int ID { get; set; }

        [Required]
        public string Title 
        {
            get { return _title; }
            set
            {
                if (value.Length > InputHandlerValue.MAX_LENGTH_TITLE)
                {
                    throw new ArgumentException();
                }

                _title = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                if (value.Length > InputHandlerValue.MAX_LENGTH_DESCRIPTION)
                {
                    throw new ArgumentException();
                }

                _description = value;
            }
        }
    }
}
