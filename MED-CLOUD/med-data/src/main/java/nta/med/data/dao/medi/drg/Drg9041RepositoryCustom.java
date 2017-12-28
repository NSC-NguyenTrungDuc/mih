package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.drgs.DRG9040U01LayPaCommentInfo;

/**
 * @author dainguyen.
 */
public interface Drg9041RepositoryCustom {
	public List<DRG9040U01LayPaCommentInfo> getDRG9040U01LayPaCommentInfo(String hospCode, String bunho);
}

