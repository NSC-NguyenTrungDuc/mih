package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch3000;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00XSavePerformerCase2Request;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SCH3001U00XSavePerformerCase2Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00XSavePerformerCase2Request, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00XSavePerformerCase2Request request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode =getHospitalCode(vertx, sessionId);
    	List<CommonModelProto.DataStringListItemInfo> lstSelectedYoil = request.getSelectedYoilList();
    	List<String> listYoilGubun = new ArrayList<String>();
    	if (!CollectionUtils.isEmpty(lstSelectedYoil)) {
			for (CommonModelProto.DataStringListItemInfo item : lstSelectedYoil) {
				listYoilGubun.add(item.getDataValue());
			}
    	}
    	
    	List<SchsModelProto.SCH3001U00XSavePerformerCase2Info> listItem = request.getItemCase2List();
    	if (!CollectionUtils.isEmpty(listItem)) {
    		List<Sch3000> listAdd = new ArrayList<Sch3000>();
			for (SchsModelProto.SCH3001U00XSavePerformerCase2Info item : listItem) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					if (!CollectionUtils.isEmpty(lstSelectedYoil)) {
						for (CommonModelProto.DataStringListItemInfo selectedYoil : lstSelectedYoil) {
							Sch3000 sch3000 = new Sch3000();
							sch3000.setSysDate(new Date());
							sch3000.setSysId(item.getUserId());
							sch3000.setUpdDate(new Date());
							sch3000.setUpdId(item.getUserId());
							sch3000.setHospCode(hospCode);
							if(!StringUtils.isEmpty(item.getJukyongDate())){
								sch3000.setJukyongDate(DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD));
							}else{
								sch3000.setJukyongDate(DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD));
							}
							sch3000.setJundalTable(item.getJundalTable());
							sch3000.setJundalPart(item.getJundalPart());
							if(!StringUtils.isEmpty(item.getGumsaja())){
								sch3000.setGumsaja(item.getGumsaja());
							}else{
								sch3000.setGumsaja("%");
							}
							sch3000.setYoilGubun(selectedYoil.getDataValue());
							sch3000.setStartTime(item.getStartTime());
							sch3000.setEndTime(item.getEndTime());
							sch3000.setInwon(CommonUtils.parseDouble(item.getInwon()));
							sch3000.setAddInwon(CommonUtils.parseDouble(item.getAddInwon()));
							
							listAdd.add(sch3000);
						}
					}
					sch3000Repository.save(listAdd);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.updateXSavePerformerCase2_1(item.getUserId(), new Date(), 
							item.getEndTime(), CommonUtils.parseDouble(item.getInwon()), CommonUtils.parseDouble(item.getAddInwon())
							, hospCode, DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD), item.getJundalTable()
							, item.getJundalPart(), listYoilGubun, item.getGumsaja(), item.getStartTime());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.deleteXSavePerformerCase2_1(hospCode, DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD), item.getJundalTable()
							, item.getJundalPart(), listYoilGubun, item.getGumsaja(), item.getStartTime());
				}
			}
    	}
    	response.setResult(true);
    	return response.build();
	}
}

