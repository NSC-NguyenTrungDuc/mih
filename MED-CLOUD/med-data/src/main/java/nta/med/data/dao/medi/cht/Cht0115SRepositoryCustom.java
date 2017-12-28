package nta.med.data.dao.medi.cht;

import nta.med.data.model.ihis.chts.CHT0115Q00GrdScInfo;
import nta.med.data.model.ihis.chts.CHT0115Q00SusikCodeInfo;
import nta.med.data.model.ihis.chts.CHT0115Q01grdCHT0115Info;

import java.util.List;

/**
 * @author dainguyen.
 */
public interface Cht0115SRepositoryCustom {

	public List<CHT0115Q01grdCHT0115Info> getCHT0115sQ01grdCHT0115ListItem(String susikDetail, Integer pageNumber, Integer offset);

}

