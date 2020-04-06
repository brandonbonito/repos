using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NumberGuessingGame.Models
{
    public class RandomNumberModel
    {
        [Required]
        [FromRoute]
        [Display(Name = "Please enter your guess (1-100): ")]
        public int Guess { get; set; }

        public int Answer { get; set; }

        [Display(Name = "Would you like to play again?")]
        public bool PlayAgain { get; set; }
    }
}
