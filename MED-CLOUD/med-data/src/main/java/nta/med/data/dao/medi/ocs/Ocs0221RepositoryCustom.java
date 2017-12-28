package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.data.model.ihis.system.ReservedCommentDloOCS0221Info;

/**
 * @author dainguyen.
 */
public interface Ocs0221RepositoryCustom {
	
	public String getOcsaOCS0221U00CommonSeq(String seqName);
	public List<ReservedCommentDloOCS0221Info> getReservedCommentDloOCS0221Info(String hospCode, String language, String memb, String categoryGubun);
}

