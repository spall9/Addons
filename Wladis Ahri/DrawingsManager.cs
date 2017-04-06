﻿using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using System.Drawing;
using EloBuddy.SDK;
using static Wladis_Ahri.Menus;
using static Wladis_Ahri.SpellsManager;
using EloBuddy.SDK.Menu.Values;
using System.Linq;

namespace Wladis_Ahri

{
    internal class DrawingsManager
    {
        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            DamageIndicator.Init();
        }


        private static void Drawing_OnDraw(EventArgs args)
        {

            var readyDraw = DrawingsMenu["readyDraw"].Cast<CheckBox>().CurrentValue;
            var target = TargetSelector.GetTarget(Q.Range + 20000, DamageType.Magical);

            //Drawings
            if (DrawingsMenu["qDraw"].Cast<CheckBox>().CurrentValue && readyDraw
            ? Q.IsReady()
            : DrawingsMenu["qDraw"].Cast<CheckBox>().CurrentValue)
                Circle.Draw(QColorSlide.GetSharpColor(), SpellsManager.Q.Range, 1f, Player.Instance);

            if (DrawingsMenu["wDraw"].Cast<CheckBox>().CurrentValue && readyDraw
             ? W.IsReady()
             : DrawingsMenu["wDraw"].Cast<CheckBox>().CurrentValue)
                Circle.Draw(WColorSlide.GetSharpColor(), SpellsManager.W.Range, 1f, Player.Instance);

            if (DrawingsMenu["eDraw"].Cast<CheckBox>().CurrentValue && readyDraw
            ? E.IsReady()
            : DrawingsMenu["eDraw"].Cast<CheckBox>().CurrentValue)
                Circle.Draw(EColorSlide.GetSharpColor(), SpellsManager.E.Range, 1f, Player.Instance);

            if (DrawingsMenu["rDraw"].Cast<CheckBox>().CurrentValue && readyDraw
            ? R.IsReady()
            : DrawingsMenu["rDraw"].Cast<CheckBox>().CurrentValue)
                Circle.Draw(RColorSlide.GetSharpColor(), SpellsManager.R.Range, 1f, Player.Instance);


            if (target.Health >
                  target.GetRealDamage() || target == null) return;
            Drawing.DrawText(Drawing.WorldToScreen(target.Position).X - 60,
                Drawing.WorldToScreen(target.Position).Y + 10,
                Color.Gold, "Killable with Combo");

        }
        public static void DrawText(string msg, AIHeroClient Hero, Color color)
        {
            var wts = Drawing.WorldToScreen(Hero.Position);
            Drawing.DrawText(wts[0] - (msg.Length) * 5, wts[1], color, msg);


        }




        private static void Drawing_OnEndScene(EventArgs args)
        {
        }
    }

}