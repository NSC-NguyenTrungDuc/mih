package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0001;
import nta.med.core.domain.sch.Sch0002;
import nta.med.core.domain.sch.Sch3000;
import nta.med.core.domain.sch.Sch3100;
import nta.med.core.domain.sch.Sch3101;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch0001Repository;
import nta.med.data.dao.medi.sch.Sch0002Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.data.dao.medi.sch.Sch3100Repository;
import nta.med.data.dao.medi.sch.Sch3101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00BtnBtnListUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
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
public class SCH3001U00BtnBtnListUpdateHandler 
	extends ScreenHandler<SchsServiceProto.SCH3001U00BtnBtnListUpdateRequest, SystemServiceProto.UpdateResponse> {
	
	@Resource
	private Sch0001Repository sch0001Repository;
	
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Resource
	private Sch0002Repository sch0002Repository;
	
	@Resource
	private Sch3100Repository sch3100Repository;
	
	@Resource
	private Sch3101Repository sch3101Repository;
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00BtnBtnListUpdateRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);    
    	//case 1
    	List<SchsModelProto.SCH3001U00GrdSCH0001Info> listISch0001tem = request.getGrdSch0001InfoList();
    	if (!CollectionUtils.isEmpty(listISch0001tem)) {
			for (SchsModelProto.SCH3001U00GrdSCH0001Info item : listISch0001tem) {
				Double gumsaTime = null;
				if(!StringUtils.isEmpty(item.getGumsaTime())){
					gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
				}
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch0001 sch0001 = new Sch0001();
					sch0001.setSysDate(new Date());
					sch0001.setSysId(request.getUserId());
					sch0001.setUpdDate(new Date());
					sch0001.setUpdId(request.getUserId());
					sch0001.setHospCode(hospCode);
					sch0001.setJundalTable(item.getJundalTable());
					sch0001.setJundalPart(item.getJundalPart());
					if(!StringUtils.isEmpty(item.getGumsaja())){
						sch0001.setGumsaja(item.getGumsaja());
					}else{
						sch0001.setGumsaja("%");
					}
					sch0001.setJundalPartName(item.getJundalPartName());
					if(!StringUtils.isEmpty(item.getGwaGubun())){
						sch0001.setGwaGubun(item.getGwaGubun());
					}else{
						sch0001.setGwaGubun("%");
					}
					sch0001.setGumsaTime(gumsaTime);
					sch0001Repository.save(sch0001);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch0001Repository.updateSCH0001XSavePerformerCase1(request.getUserId(), new Date(), 
							item.getJundalPartName(), item.getGwaGubun(), gumsaTime, hospCode,
							item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch0001Repository.deleteSCH0001XSavePerformerCase1(hospCode,
							item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				}
			}
    	}
    	
    	//case 3
    	List<SchsModelProto.SCH3001U00GrdSCH0002Info> listSch0002Item = request.getGrdSch0002InfoList();
    	if (!CollectionUtils.isEmpty(listSch0002Item)) {
			for (SchsModelProto.SCH3001U00GrdSCH0002Info item : listSch0002Item) {
				Double gumsaTime = null;
				if(!StringUtils.isEmpty(item.getGumsaTime())){
					gumsaTime = CommonUtils.parseDouble(item.getGumsaTime());
				}
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					sch0201Repository.updateXSavePerformerCase3(item.getJundalTable(), item.getJundalPart(),
							hospCode, item.getHangmogCode(), item.getGumsaja());
					
					Sch0002 sch0002 = new Sch0002();
					sch0002.setSysDate(new Date());
					sch0002.setSysId(request.getUserId());
					sch0002.setUpdDate(new Date());
					sch0002.setUpdId(request.getUserId());
					sch0002.setHospCode(hospCode);
					sch0002.setJundalTable(item.getJundalTable());
					sch0002.setJundalPart(item.getJundalPart());
					if(!StringUtils.isEmpty(item.getGumsaja())){
						sch0002.setGumsaja(item.getGumsaja());
					}else{
						sch0002.setGumsaja("%");
					}
					sch0002.setHangmogCode(item.getHangmogCode());
					sch0002.setHangmogName(item.getHangmogName());
					sch0002.setGumsaTime(gumsaTime);
					sch0002Repository.save(sch0002);
					
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch0002Repository.updateXSavePerformerCase3(request.getUserId(), new Date(), item.getHangmogName(),
							gumsaTime, hospCode, item.getJundalTable(), item.getJundalPart(), item.getHangmogCode());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch0002Repository.deleteXSavePerformerCase3(hospCode, item.getJundalTable(), item.getJundalPart(), item.getHangmogCode());
				}
			}
    	}
    	
    	//case 6
    	List<SchsModelProto.SCH3001U00GrdJukyongDateInfo> listJykyongDateItem = request.getGrdJukyongDateInfoList();
    	if (!CollectionUtils.isEmpty(listJykyongDateItem)) {
			for (SchsModelProto.SCH3001U00GrdJukyongDateInfo item : listJykyongDateItem) {
				Date jukyongDate = null;
				Date oldJukyongDate = null;
				if(!StringUtils.isEmpty(item.getJukyongDate())){
					jukyongDate = DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD);
				}
				if(!StringUtils.isEmpty(item.getOldJukyongDate())){
					oldJukyongDate = DateUtil.toDate(item.getOldJukyongDate(), DateUtil.PATTERN_YYMMDD);
				}
				if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.updateXSavePerformerCase6(request.getUserId(), new Date(), jukyongDate, 
							hospCode, oldJukyongDate, item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.deleteXSavePerformerCase6(hospCode, oldJukyongDate, item.getJundalTable(), item.getJundalPart(), item.getGumsaja());
				}
			}
    	}
    	
    	//case 7
    	List<CommonModelProto.DataStringListItemInfo> lstSelectedYoil = request.getSelectedYoilList();
    	List<String> listYoilGubun = new ArrayList<String>();
    	if (!CollectionUtils.isEmpty(lstSelectedYoil)) {
			for (CommonModelProto.DataStringListItemInfo item : lstSelectedYoil) {
				listYoilGubun.add(item.getDataValue());
			}
    	}
    	
    	List<SchsModelProto.SCH3001U00GrdSCH3000Info> listSch3000Item = request.getGrdSch3000InfoList();
    	if (!CollectionUtils.isEmpty(listSch3000Item)) {
    		List<Sch3000> listAdd = new ArrayList<Sch3000>();
			for (SchsModelProto.SCH3001U00GrdSCH3000Info item : listSch3000Item) {
				Date jukyongDate = null;
				Double inwon = null;
				Double addInwon = null;
				if(!StringUtils.isEmpty(item.getJukyongDate())){
					jukyongDate = DateUtil.toDate(item.getJukyongDate(), DateUtil.PATTERN_YYMMDD);
				}
				if(!StringUtils.isEmpty(item.getIwon())){
					inwon = CommonUtils.parseDouble(item.getIwon());
				}
				if(!StringUtils.isEmpty(item.getAddIwon())){
					addInwon = CommonUtils.parseDouble(item.getAddIwon());
				}
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					if (!CollectionUtils.isEmpty(lstSelectedYoil)) {
						for (CommonModelProto.DataStringListItemInfo selectedYoil : lstSelectedYoil) {
							Sch3000 sch3000 = new Sch3000();
							sch3000.setSysDate(new Date());
							sch3000.setSysId(request.getUserId());
							sch3000.setUpdDate(new Date());
							sch3000.setUpdId(request.getUserId());
							sch3000.setHospCode(hospCode);
							sch3000.setOutHospCodeSlot(CommonUtils.parseDouble(item.getOutHospSlot()));
						
							if(!StringUtils.isEmpty(item.getJukyongDate())){
								sch3000.setJukyongDate(jukyongDate);
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
							sch3000.setInwon(inwon);
							sch3000.setAddInwon(addInwon);
							
							listAdd.add(sch3000);
						}
					}
					sch3000Repository.save(listAdd);
				}else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.updateXSavePerformerCase2(request.getUserId(), new Date(), 
							item.getEndTime(), inwon, addInwon
							, hospCode, jukyongDate, item.getJundalTable()
							, item.getJundalPart(), listYoilGubun, item.getGumsaja(), item.getStartTime(), CommonUtils.parseDouble(item.getOutHospSlot()));
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3000Repository.deleteXSavePerformerCase2(hospCode, jukyongDate, item.getJundalTable()
							, item.getJundalPart(), listYoilGubun, item.getGumsaja(), item.getStartTime(), CommonUtils.parseDouble(item.getOutHospSlot()));
				}
				
			}
    	}
    	
    	//case 4
    	List<SchsModelProto.SCH3001U00GrdSCH3100Info> listSch3100Item = request.getGrdSch3100InfoList();
    	if (!CollectionUtils.isEmpty(listSch3100Item)) {
			for (SchsModelProto.SCH3001U00GrdSCH3100Info item : listSch3100Item) {
				Date reserDate = null;
				if(!StringUtils.isEmpty(item.getReserDate())){
					reserDate = DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD);
				}
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch3100 sch3100 = new Sch3100();
					sch3100.setSysDate(new Date());
					sch3100.setSysId(request.getUserId());
					sch3100.setUpdDate(new Date());
					sch3100.setUpdId(request.getUserId());
					sch3100.setHospCode(hospCode);
					sch3100.setJundalTable(item.getJundalTable());
					sch3100.setJundalPart(item.getJundalPart());
					sch3100.setGumsaja(item.getGumsaja());
					sch3100.setReserYn(item.getReserYn());
					sch3100.setReserDate(reserDate);
					sch3100Repository.save(sch3100);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3100Repository.updateXSavePerformerCase4(request.getUserId(), new Date(), item.getReserYn(),
							hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate);
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3100Repository.deleteXSavePerformerCase4(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate);
				}
			}
    	}
    	
    	//case 5
    	List<SchsModelProto.SCH3001U00GrdSCH3101Info> listSch3101Item = request.getGrdSch3101InfoList();
    	if (!CollectionUtils.isEmpty(listSch3101Item)) {
			for (SchsModelProto.SCH3001U00GrdSCH3101Info item : listSch3101Item) {
				Date reserDate = null;
				Double inwon = null;
				Double addInwon = null;
				if(!StringUtils.isEmpty(item.getReserDate())){
					reserDate = DateUtil.toDate(item.getReserDate(), DateUtil.PATTERN_YYMMDD);
				}
				if(!StringUtils.isEmpty(item.getIwon())){
					inwon = CommonUtils.parseDouble(item.getIwon());
				}
				if(!StringUtils.isEmpty(item.getAddIwon())){
					addInwon = CommonUtils.parseDouble(item.getAddIwon());
				}
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Sch3101 Sch3101 = new Sch3101();
					Sch3101.setSysDate(new Date());
					Sch3101.setSysId(request.getUserId());
					Sch3101.setUpdDate(new Date());
					Sch3101.setUpdId(request.getUserId());
					Sch3101.setHospCode(hospCode);
					Sch3101.setJundalTable(item.getJundalTable());
					Sch3101.setJundalPart(item.getJundalPart());
					Sch3101.setGumsaja(item.getGumsaja());
					Sch3101.setReserDate(reserDate);
					Sch3101.setStartTime(item.getStartTime());
					Sch3101.setEndTime(item.getEndTime());
					Sch3101.setInwon(inwon);
					Sch3101.setAddInwon(addInwon);
					sch3101Repository.save(Sch3101);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					sch3101Repository.updateXSavePerformerCase5(request.getUserId(), new Date(), item.getEndTime(), inwon, addInwon,
							hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate, item.getStartTime());
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					sch3101Repository.deleteXSavePerformerCase5(hospCode, item.getJundalTable(), item.getJundalPart(), item.getGumsaja(), reserDate, item.getStartTime());
				}
			}
    	}
    	
    	response.setResult(true);
    	return response.build();
	}

}
