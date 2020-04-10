using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepo
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        //READ - ("1. See all claims")
        public Queue<Claim> GetClaimQueue()
        {
            return _queueOfClaims;
        }

        //READ - See next claim in queue (first part of "2. Take care of next claim")
        public Claim GetClaimFromQueue()
        {
            return _queueOfClaims.Peek();
        }

        //DELETE - Remove claim from queue (second part of "2. Take care of next claim")
        public void RemoveClaimFromQueue()
        {
            _queueOfClaims.Dequeue();
        }

        //CREATE - ("3. Enter a new claim")
        public void AddClaimToQueue(Claim claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

    }
}
