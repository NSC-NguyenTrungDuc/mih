package nta.med.data.dao.medi.inv;

import java.util.List;

import nta.med.data.model.ihis.invs.INV4001U00Grd4002Info;

public interface Inv4002RepositoryCustom {
	public List<INV4001U00Grd4002Info> getINV4001U00Grd4002Info(String hospCode, String language, Double fkinv4001);
}
