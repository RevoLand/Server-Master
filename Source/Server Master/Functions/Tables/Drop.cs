using System;
using System.Windows;

namespace ServerMaster.Functions.Tables
{
    internal static class Drop
    {
        public static void LoadMonster_AssignedItemDrop()
        {
            try
            {
                Definitions.Listenings.Drop.Monster_AssignedItemDrop = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.Monster_AssignedItemDrop>("SELECT * FROM _RefMonster_AssignedItemDrop");

                $"[Drop] _RefMonster_AssignedItemDrop tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.Monster_AssignedItemDrop.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadMonster_AssignedItemRndDrop()
        {
            try
            {
                Definitions.Listenings.Drop.Monster_AssignedItemRndDrop = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.Monster_AssignedItemRndDrop>("SELECT * FROM _RefMonster_AssignedItemRndDrop");

                $"[Drop] _RefMonster_AssignedItemRndDrop tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.Monster_AssignedItemRndDrop.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Alchemy_ATTRStone()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Alchemy_ATTRStone = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Alchemy_ATTRStone>("SELECT * FROM _RefDropClassSel_Alchemy_ATTRStone");

                $"[Drop] _RefDropClassSel_Alchemy_ATTRStone tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Alchemy_ATTRStone.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Alchemy_MagicStone()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Alchemy_MagicStone = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Alchemy_MagicStone>("SELECT * FROM _RefDropClassSel_Alchemy_MagicStone");

                $"[Drop] _RefDropClassSel_Alchemy_MagicStone tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Alchemy_MagicStone.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Alchemy_Tablet()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Alchemy_Tablet = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Alchemy_Tablet>("SELECT * FROM _RefDropClassSel_Alchemy_Tablet");

                $"[Drop] _RefDropClassSel_Alchemy_Tablet tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Alchemy_Tablet.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Ammo()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Ammo = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Ammo>("SELECT * FROM _RefDropClassSel_Ammo");

                $"[Drop] _RefDropClassSel_Ammo tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Ammo.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Cure()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Cure = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Cure>("SELECT * FROM _RefDropClassSel_Cure");

                $"[Drop] _RefDropClassSel_Cure tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Cure.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Equip()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Equip = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Equip>("SELECT * FROM _RefDropClassSel_Equip");

                $"[Drop] _RefDropClassSel_Equip tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Equip.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_RareEquip()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_RareEquip = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_RareEquip>("SELECT * FROM _RefDropClassSel_RareEquip");

                $"[Drop] _RefDropClassSel_RareEquip tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_RareEquip.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Recover()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Recover = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Recover>("SELECT * FROM _RefDropClassSel_Recover");

                $"[Drop] _RefDropClassSel_Recover tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Recover.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Reinforce()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Reinforce = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Reinforce>("SELECT * FROM _RefDropClassSel_Reinforce");

                $"[Drop] _RefDropClassSel_Reinforce tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Reinforce.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropClassSel_Scroll()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropClassSel_Scroll = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropClassSel_Scroll>("SELECT * FROM _RefDropClassSel_Scroll");

                $"[Drop] _RefDropClassSel_Scroll tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropClassSel_Scroll.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropGold()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropGold = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropGold>("SELECT * FROM _RefDropGold");

                $"[Drop] _RefDropGold tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropGold.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropItemAssign()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropItemAssign = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropItemAssign>("SELECT * FROM _RefDropItemAssign");

                $"[Drop] _RefDropItemAssign tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropItemAssign.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropItemGroup()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropItemGroup = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropItemGroup>("SELECT * FROM _RefDropItemGroup");

                $"[Drop] _RefDropItemGroup tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropItemGroup.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadRefDropOptLvlSel()
        {
            try
            {
                Definitions.Listenings.Drop.RefDropOptLvlSel = Definitions.Listenings.SQL.Connection.Fetch<Definitions.TableData.Drops.RefDropOptLvlSel>("SELECT * FROM _RefDropOptLvlSel");

                $"[Drop] _RefDropOptLvlSel tablosu yüklendi. Tabloda {Definitions.Listenings.Drop.RefDropOptLvlSel.Count} veri bulundu.".LogToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}