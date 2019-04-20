using BookMyBrickDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyBrickDomain.Service.DeliveryCost
{
    public class DelivaryCostManagement
    {
        public double GetUserInfo(string mail)
        {
            double basecost = 999;
            double finalCost = 0;
            var context = new UserRepoContext();

            String emailTobeChecked = mail;

            User uservalue = context.User.FirstOrDefault(p => p.usermail == emailTobeChecked);

            if (uservalue.usermail == emailTobeChecked)
            {
                if (uservalue.userdistance < 10)
                {
                    finalCost = this.StaircaseValueFinder(1098, uservalue);

                   // return 1098;
                }

                if ((uservalue.userdistance > 10) && (uservalue.userdistance < 50))
                {
                    finalCost = this.StaircaseValueFinder(1248, uservalue);
                    // return 1248;
                }

                if (uservalue.userdistance > 50)
                {
                    double newdistanceCost = 00;
                    double costWithDistance = 0.25 * (uservalue.userdistance - 50);
                    newdistanceCost = basecost + costWithDistance;
                    finalCost = this.StaircaseValueFinder(newdistanceCost, uservalue);
                }
            }

            return finalCost;
        }
//=========================================>>StairecaseLogic====================>>
        public double StaircaseValueFinder(double distanceCost, User uservalue)
        {
            double totalCost=0;

            if (uservalue.stairs == 0)
            {
                totalCost = distanceCost + 999;
            }

            if ((uservalue.stairs > 1) && (uservalue.stairs <= 5))
            {
                 totalCost = distanceCost + 1048;
            }

            if (uservalue.stairs > 5)
            {
                totalCost = distanceCost + 1048 + (2 * (uservalue.stairs - 5));
            }

            return totalCost;
        }

    }
}
