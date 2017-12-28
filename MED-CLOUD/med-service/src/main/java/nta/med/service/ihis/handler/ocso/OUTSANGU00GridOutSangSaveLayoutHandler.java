package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Outsang;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.phr.SyncDiseaseInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.OcsoModelProto.OUTSANGU00InitializeListItemInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;


@Transactional
@Service                                                                                                        
@Scope("prototype")                                                                                 
public class OUTSANGU00GridOutSangSaveLayoutHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00GridOutSangSaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00GridOutSangSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;                                                                    
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00GridOutSangSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String patientCode = "";
		List<Outsang> deleteOutsangs = new ArrayList<>();
		if(CollectionUtils.isEmpty(request.getGridOutSangInfoList())){
			response.setResult(false);
		}else{
			for(OUTSANGU00InitializeListItemInfo item : request.getGridOutSangInfoList()){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Double pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode, item.getBunho(), item.getGwa(), item.getIoGubun());
					if(pkSeq == null){
						pkSeq = 1.0;
					}
					Double ser = outsangRepository.getOUTSANGU00Ser(hospCode, item.getBunho());
					if(ser == null){
						ser = 1.0;
					}
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode, item.getIoGubun(), item.getGwa(),
							item.getBunho(), item.getFkinp1001(), item.getSangCode(), item.getSangName(), item.getPostModifierName(),
							item.getPreModifierName(), item.getSangStartDate(), item.getSangEndDate(), item.getSangJindanDate(),
							item.getDataGubun(),item.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
					}else{
						response.setResult(insertOUTSANGU00(item, pkSeq,ser, request.getUserId(), hospCode));
					}
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode, item.getIoGubun(), item.getGwa(),
							item.getBunho(), item.getFkinp1001(), item.getSangCode(),item.getSangName(), item.getPostModifierName(),
							item.getPreModifierName(), item.getSangStartDate(), item.getSangEndDate(), item.getSangJindanDate(),
							item.getDataGubun(), item.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
					}else{
						response.setResult(updateOUTSANGU00(item, request.getUserId(), hospCode));
					}
				}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
						String ifDataSendYn = outsangRepository.getIfDataSendYn(hospCode, item.getBunho(), item.getGwa(), item.getIoGubun(),
								CommonUtils.parseDouble(item.getPkSeq()));
						if(item.getDataGubun().equalsIgnoreCase("I") && ifDataSendYn.equalsIgnoreCase("N")){
							List<Outsang> deleteList = deleteOUTSANGU00(item, hospCode);
							response.setResult(!CollectionUtils.isEmpty(deleteList));
							deleteOutsangs.addAll(deleteList);
						}else{
							List<Outsang> deleteList = deleteOUTSANGU00(item, hospCode);
							response.setResult(!CollectionUtils.isEmpty(deleteList));
							deleteOutsangs.addAll(deleteList);
						}
					}
				}
			}
			patientCode = request.getGridOutSangInfoList().get(0).getBunho();
		}
		// sync disease event
		if(response.getResult() && !StringUtils.isEmpty(patientCode)) {
			LOGGER.info("EVENT_SYNC_DISEASE: OUTSANGU00GridOutSangSaveLayoutHandler!!!");
			NuroServiceProto.PatientEvent.Builder message = NuroServiceProto.PatientEvent.newBuilder();
			if(!CollectionUtils.isEmpty(deleteOutsangs)){
				for (Outsang outsang : deleteOutsangs) {
					NuroModelProto.SyncDisease.Builder info = NuroModelProto.SyncDisease.newBuilder();
					info.setSyncId(outsang.getId());
					info.setIsDelete(true);
					message.addDiseaseInfo(info);
				}
			}
			
			List<SyncDiseaseInfo> listData = outsangRepository.getSyncDiseaseInfo(hospCode, patientCode, getLanguage(vertx, sessionId));
			if(!CollectionUtils.isEmpty(listData))
			{
				for (SyncDiseaseInfo syncDiseaseInfo : listData) {
					NuroModelProto.SyncDisease.Builder info = NuroModelProto.SyncDisease.newBuilder();
					BeanUtils.copyProperties(syncDiseaseInfo, info, getLanguage(vertx, sessionId));
					info.setDatetimeRecord(DateUtil.toString(syncDiseaseInfo.getDatetimeRecord(), DateUtil.PATTERN_YYYY_MM_DD));
					info.setDiseaseStartDate(DateUtil.toString(syncDiseaseInfo.getDiseaseStartDate(), DateUtil.PATTERN_YYYY_MM_DD));
					info.setDiseaseEndDate(DateUtil.toString(syncDiseaseInfo.getDiseaseEndDate(), DateUtil.PATTERN_YYYY_MM_DD));
					info.setSyncId(syncDiseaseInfo.getSyncId().longValue());
					message.addDiseaseInfo(info);
				}
			}

			LOGGER.info("PUBLISH EVENT_SYNC_DISEASE: OUTSANGU00GridOutSangSaveLayoutHandler!!!");
			message.setPatientCode(patientCode);
			message.setHospCode(hospCode);
			publish(vertx, message.build());
		}
		return response.build();
	}
	
	public boolean insertOUTSANGU00(OUTSANGU00InitializeListItemInfo item,Double pkSeq, Double ser, String userId, String hospCode){		
		Outsang outsang = new Outsang();
	
	outsang.setSysDate(new Date());
	outsang.setSysId(userId);
	outsang.setBunho(item.getBunho());
	outsang.setHospCode(hospCode);
	outsang.setGwa(item.getGwa());
	outsang.setIoGubun (item.getIoGubun()); 
	outsang.setPkSeq(pkSeq);
	if(!item.getNaewonDate().isEmpty() && DateUtil.toDate(item.getNaewonDate(),DateUtil.PATTERN_YYMMDD) != null){
		outsang.setNaewonDate (DateUtil.toDate(item.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
	}

	outsang.setDoctor (item.getDoctor());
	outsang.setNaewonType (item.getNaewonType());
	if(item.getJubsuNo()!= null && !item.getJubsuNo().isEmpty() ){
		outsang.setJubsuNo(CommonUtils.parseDouble(item.getJubsuNo()));
	}
	if(item.getNaewonDate() != null && !item.getNaewonDate().isEmpty()){
		outsang.setLastNaewonDate (DateUtil.toDate(item.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
	}
	outsang.setLastDoctor(item.getDoctor());
	outsang.setLastNaewonType(item.getNaewonType());
	if(item.getJubsuNo()!= null && !item.getJubsuNo().isEmpty() ){
		outsang.setLastJubsuNo(CommonUtils.parseDouble(item.getJubsuNo()));
	}
	if(item.getFkinp1001()!= null && !item.getFkinp1001().isEmpty() ){
		outsang.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
	}
	outsang.setInputId(userId);
		outsang.setSer(ser);
	outsang.setSangCode(item.getSangCode());
	outsang.setJuSangYn(item.getJuSangYn());
	outsang.setSangName (item.getSangName());
	if(!item.getSangStartDate().isEmpty() && DateUtil.toDate(item.getSangStartDate(),DateUtil.PATTERN_YYMMDD) != null){
		outsang.setSangStartDate (DateUtil.toDate(item.getSangStartDate(),DateUtil.PATTERN_YYMMDD)); 
	}
	if(!item.getSangEndDate().isEmpty() && DateUtil.toDate(item.getSangEndDate(),DateUtil.PATTERN_YYMMDD) != null){
		outsang.setSangEndDate (DateUtil.toDate(item.getSangEndDate(),DateUtil.PATTERN_YYMMDD)); 
	}
	outsang.setSangEndSayu(item.getSangEndSayu());
	outsang.setPreModifier1 (item.getPreModifier1());
	outsang.setPreModifier2(item.getPreModifier2());
	outsang.setPreModifier3(item.getPreModifier3());
	outsang.setPreModifier4(item.getPreModifier4());
	outsang.setPreModifier5 (item.getPreModifier5());
	outsang.setPreModifier6(item.getPreModifier6());
	outsang.setPreModifier7(item.getPreModifier7());
	outsang.setPreModifier8(item.getPreModifier8());
	outsang.setPreModifier9 (item.getPreModifier9());
	outsang.setPreModifier10(item.getPreModifier10());
	outsang.setPreModifierName(item.getPreModifierName());
	outsang.setPostModifier1(item.getPostModifier1());
	outsang.setPostModifier2(item.getPostModifier2());
	outsang.setPostModifier3(item.getPostModifier3());
	outsang.setPostModifier4(item.getPostModifier4());
	outsang.setPostModifier5(item.getPostModifier5());
	outsang.setPostModifier6(item.getPostModifier6());
	outsang.setPostModifier7(item.getPostModifier7());
	outsang.setPostModifier8(item.getPostModifier8());
	outsang.setPostModifier9(item.getPostModifier9());
	outsang.setPostModifier10(item.getPostModifier10());
	outsang.setPostModifierName(item.getPostModifierName());
	if(!item.getSangJindanDate().isEmpty() && DateUtil.toDate(item.getSangJindanDate(),DateUtil.PATTERN_YYMMDD) != null){
		outsang.setSangJindanDate (DateUtil.toDate(item.getSangJindanDate(),DateUtil.PATTERN_YYMMDD)); 
	}
	outsang.setDataGubun(item.getDataGubun());
	outsang.setEmrPermission(CommonUtils.parseBigDecimal(item.getEmrPermission()));
	outsangRepository.save(outsang);
	return true;
	}
	
	public boolean updateOUTSANGU00(OUTSANGU00InitializeListItemInfo item, String userId, String hospCode){		
	Double ser = 0.0;
	Double pkSeq = 0.0;
	if(item.getSer() != null && !item.getSer().isEmpty()){
		ser = CommonUtils.parseDouble(item.getSer());
	}
	if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
		pkSeq = CommonUtils.parseDouble(item.getPkSeq());
	}
	
	Date sangStartDate = new Date();
	Date sangEndDate = null;
	Date sangJindanDate = null;
	if(!item.getSangStartDate().isEmpty() && DateUtil.toDate(item.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
		sangStartDate = DateUtil.toDate(item.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
	}
	if(!item.getSangEndDate().isEmpty() && DateUtil.toDate(item.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
		sangEndDate = DateUtil.toDate(item.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
	}
	if(!item.getSangJindanDate().isEmpty() && DateUtil.toDate(item.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
		sangJindanDate = DateUtil.toDate(item.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
	}
	if(outsangRepository.updateOUTSANGOU00TransactionExt(
			userId, 
			ser, 
			item.getSangName(), 
			sangStartDate, 
			sangEndDate, 
			item.getSangEndSayu(), 
			item.getJuSangYn(),
			item.getPreModifier1(), 
			item.getPreModifier2(), 
			item.getPreModifier3(), 
			item.getPreModifier4(), 
			item.getPreModifier5(), 
			item.getPreModifier6(), 
			item.getPreModifier7(), 
			item.getPreModifier8(), 
			item.getPreModifier9(), 
			item.getPreModifier10(), 
			item.getPreModifierName(), 
			item.getPostModifier1(), 
			item.getPostModifier2(), 
			item.getPostModifier3(), 
			item.getPostModifier4(), 
			item.getPostModifier5(), 
			item.getPostModifier6(), 
			item.getPostModifier7(), 
			item.getPostModifier8(), 
			item.getPostModifier9(), 
			item.getPostModifier10(), 
			item.getPostModifierName(), 
			sangJindanDate, 
			item.getDataGubun(),
			CommonUtils.parseBigDecimal(item.getEmrPermission()),
			item.getBunho(), 
			item.getGwa(), 
			item.getIoGubun(), 
			pkSeq, 
			hospCode) > 0){
			return true;
		}else{
			return false;
		}
	
	}
	
	public List<Outsang> deleteOUTSANGU00(OUTSANGU00InitializeListItemInfo item, String hospCode){
		Double pkSeq = 0.0;
		if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
			pkSeq = CommonUtils.parseDouble(item.getPkSeq());
		}
		List<Outsang> listOutsang = outsangRepository.getOUTSANGU00Transaction(
				item.getBunho(),
				item.getGwa(),
				item.getIoGubun(),
				pkSeq,
				hospCode);
		if(outsangRepository.deleteOUTSANGU00Transaction(
				item.getBunho(),
				item.getGwa(),
				item.getIoGubun(),
				pkSeq,
				hospCode) > 0){
			return listOutsang;
		}else{	
			return null;
		}
	}
	
}