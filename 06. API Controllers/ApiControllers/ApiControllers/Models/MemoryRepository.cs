using System.Collections.Generic;

namespace ApiControllers.Models
{
    // nonpersistent implementation    
    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Reservation> items;

        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation>
            {
                new Reservation {ClientName = "Pesho", Location = "Sofia" },
                new Reservation {ClientName = "Ivan", Location = "Varna" },
                new Reservation {ClientName = "Maria", Location = "Veliko Tarnovo" },
            }.ForEach(r => AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; }
                reservation.Id = key;
            }

            items[reservation.Id] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);

        public Reservation UpdateReservation(Reservation reservation)
           => AddReservation(reservation);
    }
}
