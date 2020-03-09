using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Messaging;
using WpfApplication1.Data;

namespace WpfApplication1.BL
{
    interface IPlayerLogic
    {
        void AddPlayer(IList<Player> list);
        void ModPlayer(Player playerToModify);
        void DelPlayer(IList<Player> list, Player player);
    }

    class PlayerLogic : IPlayerLogic
    {
        IEditorService editorService;
        IMessenger messengerService;
        // IMessenger: dependency "2 layers up" ???
        // Not really layer-bound interface/service... 
        // Detailed in the lecture: Aspect-Oriented Programming!!!

        public PlayerLogic(IEditorService service, IMessenger messenger)
        {
            this.editorService = service;
            this.messengerService = messenger;
        }

        public void AddPlayer(IList<Player> list)
        {
            Player newPlayer = new Player();
            if (editorService.EditPlayer(newPlayer) == true)
            {
                list.Add(newPlayer);
                messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                messengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        public void ModPlayer(Player playerToModify)
        {
            if (playerToModify == null) return;

            Player clone = new Player();
            clone.CopyFrom(playerToModify);
            if (editorService.EditPlayer(clone) == true)
            {
                playerToModify.CopyFrom(clone);
                messengerService.Send("EDIT OK", "LogicResult");
            } else
            {
                messengerService.Send("EDIT CANCEL", "LogicResult");
            }
        }

        public void DelPlayer(IList<Player> list, Player player)
        {
            list.Remove(player);
        }
    }
}