package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;

public interface Bas0260SRepositoryCustom {

	public List<LoadGrdBAS0260U01Info> getBas0260SListGetDepartment(String language, String buseoName, String gwaName, String activeFlg, String hospCode, String buseoGubun);
	public boolean isExistedBAS0260S(String buseoCode, String gwa, String language);
}

