﻿/*
 *  "GEDKeeper", the personal genealogical database editor.
 *  Copyright (C) 2009-2023 by Sergey V. Zhdanovskih.
 *
 *  This file is part of "GEDKeeper".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using GDModel;
using GKCore.Design;
using GKCore.Design.Controls;
using GKCore.Design.Views;
using GKCore.Interfaces;
using GKCore.Lists;
using GKCore.Types;

namespace GKCore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SourceEditDlgController : DialogController<ISourceEditDlg>
    {
        private GDMSourceRecord fSourceRecord;

        public GDMSourceRecord SourceRecord
        {
            get { return fSourceRecord; }
            set {
                if (fSourceRecord != value) {
                    fSourceRecord = value;
                    UpdateView();
                }
            }
        }


        public SourceEditDlgController(ISourceEditDlg view) : base(view)
        {
            fView.ShortTitle.Activate();
        }

        public override void Init(IBaseWindow baseWin)
        {
            base.Init(baseWin);

            fView.RepositoriesList.ListModel = new SourceRepositoriesListModel(fView, baseWin, fLocalUndoman);
            fView.NotesList.ListModel = new NoteLinksListModel(fView, baseWin, fLocalUndoman);
            fView.MediaList.ListModel = new MediaLinksListModel(fView, baseWin, fLocalUndoman);
        }

        public override bool Accept()
        {
            try {
                fSourceRecord.ShortTitle = fView.ShortTitle.Text;
                fSourceRecord.Originator.Clear();
                fSourceRecord.SetOriginatorArray(fView.Author.Lines);
                fSourceRecord.Title.Clear();
                fSourceRecord.SetTitleArray(fView.DescTitle.Lines);
                fSourceRecord.Publication.Clear();
                fSourceRecord.SetPublicationArray(fView.Publication.Lines);
                fSourceRecord.Text.Clear();
                fSourceRecord.SetTextArray(fView.Text.Lines);

                fLocalUndoman.Commit();

                fBase.NotifyRecord(fSourceRecord, RecordAction.raEdit);

                return true;
            } catch (Exception ex) {
                Logger.WriteError("SourceEditDlgController.Accept()", ex);
                return false;
            }
        }

        public override void UpdateView()
        {
            fView.ShortTitle.Text = fSourceRecord.ShortTitle;
            fView.Author.Text = fSourceRecord.Originator.Lines.Text.Trim();
            fView.DescTitle.Text = fSourceRecord.Title.Lines.Text.Trim();
            fView.Publication.Text = fSourceRecord.Publication.Lines.Text.Trim();
            fView.Text.Text = fSourceRecord.Text.Lines.Text.Trim();

            fView.RepositoriesList.ListModel.DataOwner = fSourceRecord;
            fView.NotesList.ListModel.DataOwner = fSourceRecord;
            fView.MediaList.ListModel.DataOwner = fSourceRecord;
        }

        public override void SetLocale()
        {
            fView.Title = LangMan.LS(LSID.Source);

            GetControl<IButton>("btnAccept").Text = LangMan.LS(LSID.DlgAccept);
            GetControl<IButton>("btnCancel").Text = LangMan.LS(LSID.DlgCancel);
            GetControl<ILabel>("lblShortTitle").Text = LangMan.LS(LSID.ShortTitle);
            GetControl<ILabel>("lblAuthor").Text = LangMan.LS(LSID.Author);
            GetControl<ILabel>("lblTitle").Text = LangMan.LS(LSID.Title);
            GetControl<ILabel>("lblPublication").Text = LangMan.LS(LSID.Publication);
            GetControl<ITabPage>("pageCommon").Text = LangMan.LS(LSID.Common);
            GetControl<ITabPage>("pageText").Text = LangMan.LS(LSID.Text);
            GetControl<ITabPage>("pageRepositories").Text = LangMan.LS(LSID.RPRepositories);
            GetControl<ITabPage>("pageNotes").Text = LangMan.LS(LSID.RPNotes);
            GetControl<ITabPage>("pageMultimedia").Text = LangMan.LS(LSID.RPMultimedia);
        }
    }
}
