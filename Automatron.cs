using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMassignment4
{
    public class Automatron
    {
        
        Dictionary<int, StateModel> state = new Dictionary<int, StateModel>();

        public void ParseLog(int choice){
            string[] lines;
            if(choice == 1)
                lines = File.ReadAllLines("logfilSucces.txt");
            else
                lines = File.ReadAllLines("logfilFail.txt");

            
            foreach (var item in lines)
            {
                var newState = new StateModel(){
                    Session=int.Parse(item.Split(':')[0]),
                    Action=int.Parse(item.Split(':')[1]),
                    UnixTimeStamp=int.Parse(item.Split(':')[2]),
                };
                
                if(!state.ContainsKey(newState.Session)){
                    state.Add(newState.Session,
                        new StateModel(){Session=newState.Session, Action=0, UnixTimeStamp=newState.UnixTimeStamp}
                    );
                }
                if(Allowed(state[newState.Session].Action,newState.Action)){
                    state[newState.Session]=newState;
                    System.Console.WriteLine($"State change issued for user({state[newState.Session].Session}) - Desired-state : ({state[newState.Session].Action})");
                }else
                {
                    System.Console.WriteLine($"Illegal state change cant execute action from {state[newState.Session].Action} to {newState.Action}");
                }
                
            }

        }

        public bool Allowed(int state, int desiredState){
            Dictionary<int, int[]> rules = new Dictionary<int, int[]>();
            rules.Add(0, new int[]{1});
            rules.Add(1, new int[]{2,3,4} );
            rules.Add(2, new int[]{2,3,4} );
            rules.Add(3, new int[]{2,3,4} );
            rules.Add(4, new int[]{0} );

            return rules[state].Contains(desiredState);

        }

    }
}