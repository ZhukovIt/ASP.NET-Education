using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public static class Repository
    {
        private static List<GuestResponse> m_GuestResponses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> GuestResponses
        {
            get
            {
                return m_GuestResponses;
            }
        }

        public static void AddGuestResponse(GuestResponse guestResponse)
        {
            m_GuestResponses.Add(guestResponse);
        }
    }
}
