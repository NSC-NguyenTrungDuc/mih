using System;
using System.Collections.Generic;

using System.Text;

namespace MedicalInterface
{
    using MedicalInterface.Mml23;
    using MedicalInterface.Mml23.MmlFc;
    using MedicalInterface.Mml23.MmlPsi;

    public class InterfaceFacade : IDisposable
    {
        private FacilityInfo _facility;
        private ParsonInfo _creatorParson;
        private PersonalizedInfo _personalizedInfo;

        public FacilityInfo Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }

        public ParsonInfo CreatorParson
        {
            get { return _creatorParson; }
            set { _creatorParson = value; }
        }

        public PersonalizedInfo PersonalizedInfo
        {
            get { return _personalizedInfo; }
            set { _personalizedInfo = value; }
        }

        public InterfaceFacade()
        {

        }

        public Mml23.Mml ReadMml23(string fileOrContent, bool readFromFile)
        {
            Mml23.MmlReader reader = new Mml23.MmlReader();
            Mml23.Mml mml = reader.Read(fileOrContent, readFromFile);
            return mml;
        }

        public Mml23.Mml CreateMml23(string patientno)
        {
            Mml23.Mml mml = new Mml23.Mml();

            mml.Header = new Mml23.MmlHeader();
            mml.Header.MasterId.Text = patientno;

            if (this.PersonalizedInfo != null)
            {
                mml.Header.Creator.Parson = this.PersonalizedInfo;
            }

            if (this.CreatorParson != null)
            {
                mml.Header.Creator.LicenseList.Add(new Mml23.MmlCi.CreatorLicense(this.CreatorParson.ProfessionCode));
            }

            //if (this.Facility != null)
            //{
            //    //mml.Header.Creator.Parson.Facility.Id.Text = this.Facility.FacilityId;
            //    //mml.Header.Creator.Parson.Facility.Id.IdType = this.Facility.Type;
            //    //mml.Header.Creator.Parson.Facility.Id.TableId = this.Facility.TableId;
            //    mml.Header.Creator.Parson.Facility.Name = this.Facility.FacilityName;
            //    //mml.Header.Creator.Parson.AddressList.Add(new Mml23.MmlAd.Address(this.Facility.PostNumber, this.Facility.AddressText));
            //    mml.Header.Creator.Parson.AddressList.Add(this.Facility.Address);
            //}

            //if (this.CreatorParson != null)
            //{
            //    mml.Header.Creator.Parson.ParsonId.Text = this.CreatorParson.ParsonalId;
            //    mml.Header.Creator.Parson.ParsonName.FamilyName = this.CreatorParson.KanjiFamilyName;
            //    mml.Header.Creator.Parson.ParsonName.GivenName = this.CreatorParson.KanjiGivenName;
            //    mml.Header.Creator.Parson.Department.Id.Text = this.CreatorParson.DepartmentCode;
            //    //added 2015/11/03
            //    mml.Header.Creator.Parson.ParsonName.FullName = this.CreatorParson.FullName;
            //    //end

            //    mml.Header.Creator.Parson.Department.Name = mml.TableManager.Mml0028.GetDescription(this.CreatorParson.DepartmentCode);
            //    mml.Header.Creator.LicenseList.Add(new Mml23.MmlCi.CreatorLicense(this.CreatorParson.ProfessionCode));
            //}

            mml.Body = new Mml23.MmlBody();

            return mml;
        }

        public void WriteMml23(Mml23.Mml mml, string filename)
        {
            MmlWriter writer = new Mml23.MmlWriter();

            writer.Write(mml, filename);
        }

        public string WriteMml23(Mml23.Mml mml)
        {
            MmlWriter writer = new Mml23.MmlWriter();

            return writer.Write(mml);
        }

        #region IDisposable メンバ

        public void Dispose()
        {
        }

        #endregion
    }
}
