﻿namespace WebApi.Models.Entity
{
	public class Review
	{
		public int Id { get; set; }

		public int TourId { get; set; }
		public Tour Tour { get; set; }

		public string ClientId { get; set; }
		public Client Client { get; set; }

		public int Rating { get; set; }
		public string Comment { get; set; }

		public DateTime Date { get; set; }

	}
}
