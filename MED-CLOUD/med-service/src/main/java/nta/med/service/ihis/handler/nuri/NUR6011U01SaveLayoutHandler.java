package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur6011;
import nta.med.core.domain.nur.Nur6012;
import nta.med.core.domain.nur.Nur6014;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur6011Repository;
import nta.med.data.dao.medi.nur.Nur6012Repository;
import nta.med.data.dao.medi.nur.Nur6014Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR6011U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {  
	
	private static final Log LOGGER = LogFactory.getLog(NUR6011U01SaveLayoutHandler.class); 	
	
	@Resource                                   
	private Nur6011Repository nur6011Repository;
	
	@Resource                                   
	private Nur6012Repository nur6012Repository;
	
	@Resource                                   
	private Nur6014Repository nur6014Repository;

	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01SaveLayoutRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<NuriModelProto.NUR6011U01grdNur6011Info> nur6011InfoList = request.getGrdNur6011InfoList();
		List<NuriModelProto.NUR6011U01grdNur6012Info> nur6012InfoList = request.getGrdNur6012InfoList();
		List<NuriModelProto.NUR6011U01grdImageInfo> imageInfoList = request.getGrdImageInfoList();
		
		response.setResult(true);
		
		for(NuriModelProto.NUR6011U01grdNur6011Info item : nur6011InfoList){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				
				if(nur6011Repository.nUR6011U01SaveLayoutUpdateNUR6011(hospCode, item.getBunho(), item.getFromDate()) < 0){
					LOGGER.info(String.format("NUR6011U01SaveLayoutUpdateNUR6011 fail for bunho = %s", item.getBunho()));
					throw new ExecutionException(response.setResult(false).build());
				}
				Date fromDate = DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD);
				Date endDate = DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD);
				
				if(endDate.compareTo(fromDate) < 0){
					LOGGER.info(String.format("StartDateError for bunho = %s", item.getBunho()));
					throw new ExecutionException(response.setResult(false).setMsg("StartDateError").build());
				}

				if(!insertNur6011(item, hospCode, userId)){
					throw new ExecutionException(response.setResult(false).build());
				}
				
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur6011Repository.updateNur6011SaveLayout(hospCode, item.getBunho(), userId, item.getEndDate(), item.getBedsoreBuwi1(), item.getBedsoreBuwi2(),
						item.getBedsoreBuwi3(), item.getBedsoreBuwi4(), item.getBedsoreBuwi5(), item.getBedsoreBuwi6(), item.getFromDate()) < 0){
					throw new ExecutionException(response.setResult(false).build());
				};
				
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				
				if(nur6012Repository.NUR6012CheckIsExist(hospCode, item.getBunho(), item.getFromDate()).equals("Y")){
					LOGGER.info(String.format("DoneError for bunho = %s", item.getBunho()));
					throw new ExecutionException(response.setResult(false).setMsg("DoneError").build());
				}
				
				if(nur6011Repository.deleteNur6011SaveLayout(hospCode, item.getBunho(), item.getFromDate()) > 0){
					if(nur6012Repository.deleteNur6012SaveLayout(hospCode, item.getBunho(), item.getFromDate()) < 0){
						throw new ExecutionException(response.setResult(false).build());
					}
				}else{
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		for(NuriModelProto.NUR6011U01grdNur6012Info item : nur6012InfoList){
			
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				String isExist = nur6011Repository.getNUR6011SaveLayoutIsExist(hospCode, item.getBunho(), item.getFromDate(), item.getAssessorDate());
				if(isExist != null && !isExist.equals("Y")){
					LOGGER.info(String.format("EndateError for bunho = %s", item.getBunho()));
					throw new ExecutionException(response.setResult(false).setMsg("EndateError").build());
				}
				
				if(!insertNur6012(item, hospCode, userId)){
					throw new ExecutionException(response.setResult(false).build());
				}
				
			} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur6012Repository.updateNur6012SaveLayout(hospCode, item.getBunho(), item.getFromDate(), item.getBedsoreBuwi(), item.getAssessorDate(), userId,
						item.getAssessor(), item.getBedsoreDeep(), CommonUtils.parseDouble(item.getBedsoreDeath()), item.getBedsoreColor(),
						CommonUtils.parseDouble(item.getBedsoreSize1()), 
						CommonUtils.parseDouble(item.getBedsoreSizeStart1()), 
						CommonUtils.parseDouble(item.getBedsoreSizeFinish1()), 
						CommonUtils.parseDouble(item.getBedsorePoket1()), 
						CommonUtils.parseDouble(item.getBedsorePoketStart1()), 
						CommonUtils.parseDouble(item.getBedsorePoketFinish1()), 
						item.getBedsoreDeath(),
						item.getExudationVolume(),
						item.getExudationState(),
						item.getExudationColor(),
						item.getExudationSmell(),
						item.getBedsoreSkin(),
						item.getBedsoreInfe(),
						item.getBedsoreMoist(),
						CommonUtils.parseDouble(item.getBedsoreMoistRate()), 
						item.getBedsoreGita(),
						item.getBedsoreNut(),
						CommonUtils.parseDouble(item.getBedsoreHb()), 
						CommonUtils.parseDouble(item.getBedsoreAlb()), 
						CommonUtils.parseDouble(item.getBedsoreFbs()), 
						CommonUtils.parseDouble(item.getBedsoreZn()), 
						CommonUtils.parseDouble(item.getBedsoreSize2()), 
						CommonUtils.parseDouble(item.getBedsoreSizeStart2()), 
						CommonUtils.parseDouble(item.getBedsoreSizeFinish2()), 
						CommonUtils.parseDouble(item.getBedsorePoket2()), 
						CommonUtils.parseDouble(item.getBedsorePoketStart2()), 
						CommonUtils.parseDouble(item.getBedsorePoketFinish2()), 
						item.getEndYn(),
						item.getExudationState1(),
						item.getExudationState2(),
						item.getBedsoreColor2(),
						item.getBedsoreColor3(),
						item.getBedsoreColor4(),
						item.getFirstSayu(),
						item.getLastSayu(),
						item.getYokchangDeep(),
						item.getSamchulYang(),
						item.getYokchangSize(),
						CommonUtils.parseDouble(item.getYokchangSizeStart()), 
						CommonUtils.parseDouble(item.getYokchangSizeEnd()), 
						item.getYokchangGamyum(),
						item.getYukajojik(),
						item.getGaesajojik(),
						item.getPocketGubun(),
						CommonUtils.parseDouble(item.getPocketSizeStart()), 
						CommonUtils.parseDouble(item.getPocketSizeEnd()), 
						item.getYokchangStage(),
						CommonUtils.parseDouble(item.getTotalCount()), 
						item.getYungyangSiksaGubun(),
						CommonUtils.parseDouble(item.getYungyangSiksaYang()), 
						CommonUtils.parseDouble(item.getYungyangSiksaPercent()), 
						item.getYungyangSuaekYn(),
						CommonUtils.parseDouble(item.getYungyangSuaekYang()), 
						item.getChuchiText(),
						CommonUtils.parseDouble(item.getYokchangHb()), 
						CommonUtils.parseDouble(item.getYokchangAlb()), 
						CommonUtils.parseDouble(item.getYokchangTp())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur6012Repository.NUR6012CheckIsExist(hospCode, item.getBunho(), item.getFromDate()).equals("Y")){
					LOGGER.info(String.format("DeleteError for bunho = %s", item.getBunho()));
					throw new ExecutionException(response.setResult(false).setMsg("DeleteError").build());
				}
				if(nur6012Repository.deleteNur6012FromNUR6011(hospCode, item.getBunho(), item.getFromDate(), item.getBedsoreBuwi(), item.getAssessorDate()) < 0){
					throw new ExecutionException(response.setResult(false).setMsg("DeleteError").build());
				}
			}
		}
		
		for(NuriModelProto.NUR6011U01grdImageInfo item : imageInfoList){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
//				String assessorDate = item.getAssessorDate().replaceAll("/", "").replaceAll("-", "").substring(0, 8);				
//				String[] arrayFile = item.getBaseImagePath().split("\\.");
				String fileName = "";
				
//				if(item.getImage().length() > 0){
//					fileName = item.getBunho() + assessorDate + item.getBuwiGubun() + "." + arrayFile[arrayFile.length - 1].toString().toUpperCase();
//				}
				
				if(!insertNur6014(item, hospCode, userId, fileName)){
					throw new ExecutionException(response.setResult(false).build());
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur6014Repository.deleteNur6014SaveLayout(hospCode, item.getBunho(), item.getFromDate(), item.getBuwiGubun(), item.getAssessorDate(),
						CommonUtils.parseDouble(item.getSeq())) < 0){
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		return response.build();
	}
	
	private boolean insertNur6011(NuriModelProto.NUR6011U01grdNur6011Info item, String hospCode, String userId){
		Nur6011 nur6011 = new Nur6011();
		
		nur6011.setSysDate(new Date());
		nur6011.setSysId(userId);
		nur6011.setUpdDate(new Date());
		nur6011.setUpdId(userId);
		nur6011.setHospCode(hospCode);
		nur6011.setBunho(item.getBunho());
		
		if(!item.getFromDate().isEmpty() && DateUtil.toDate(item.getFromDate(),DateUtil.PATTERN_YYMMDD) != null){
			nur6011.setFromDate(DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		if(!item.getEndDate().isEmpty() && DateUtil.toDate(item.getEndDate(),DateUtil.PATTERN_YYMMDD) != null){
			nur6011.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		nur6011.setBedsoreBuwi1(item.getBedsoreBuwi1());
		nur6011.setBedsoreBuwi2(item.getBedsoreBuwi2());
		nur6011.setBedsoreBuwi3(item.getBedsoreBuwi3());
		nur6011.setBedsoreBuwi4(item.getBedsoreBuwi4());
		nur6011.setBedsoreBuwi5(item.getBedsoreBuwi5());
		nur6011.setBedsoreBuwi6(item.getBedsoreBuwi6());
		nur6011.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		
		nur6011Repository.save(nur6011);
		
		return true;
	}
	
	private boolean insertNur6012(NuriModelProto.NUR6011U01grdNur6012Info item, String hospCode, String userId){
		Nur6012 nur6012 = new Nur6012();
		
		nur6012.setSysDate(new Date());
		nur6012.setSysId(userId);
		nur6012.setUpdDate(new Date());
		nur6012.setUpdId(userId);
		nur6012.setHospCode(hospCode);
		nur6012.setBunho(item.getBunho());
		
		if(!item.getFromDate().isEmpty() && DateUtil.toDate(item.getFromDate(),DateUtil.PATTERN_YYMMDD) != null){
			nur6012.setFromDate(DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		nur6012.setBedsoreBuwi(item.getBedsoreBuwi());
		
		if(!item.getAssessorDate().isEmpty() && DateUtil.toDate(item.getAssessorDate(),DateUtil.PATTERN_YYMMDD) != null){
			nur6012.setAssessorDate(DateUtil.toDate(item.getAssessorDate(), DateUtil.PATTERN_YYMMDD));
		}
		
		nur6012.setAssessor(item.getAssessor());
		nur6012.setBedsoreDeep(item.getBedsoreDeep());
		nur6012.setBedsoreDepth(CommonUtils.parseDouble(item.getBedsoreDepth()));
		nur6012.setBedsoreColor(item.getBedsoreColor());
		nur6012.setBedsoreSize1(CommonUtils.parseDouble(item.getBedsoreSize1()));
		nur6012.setBedsoreSizeStart1(CommonUtils.parseDouble(item.getBedsoreSizeStart1()));
		nur6012.setBedsoreSizeFinish1(CommonUtils.parseDouble(item.getBedsoreSizeFinish1()));
		nur6012.setBedsoreDeath(item.getBedsoreDeath());
		nur6012.setExudationVolume(item.getExudationVolume());
		nur6012.setExudationState(item.getExudationState());
		nur6012.setExudationColor(item.getExudationColor());
		nur6012.setExudationSmell(item.getExudationSmell());
		nur6012.setBedsoreSkin(item.getBedsoreSkin());
		nur6012.setBedsoreInfe(item.getBedsoreInfe());
		nur6012.setBedsoreMoist(item.getBedsoreMoist());
		nur6012.setBedsoreMoistRate(CommonUtils.parseDouble(item.getBedsoreMoistRate()));
		nur6012.setBedsoreGita(item.getBedsoreGita());
		nur6012.setBedsoreNut(item.getBedsoreNut());
		nur6012.setBedsoreHb(CommonUtils.parseDouble(item.getBedsoreHb()));
		nur6012.setBedsoreAlb(CommonUtils.parseDouble(item.getBedsoreAlb()));
		nur6012.setBedsoreFbs(CommonUtils.parseDouble(item.getBedsoreFbs()));
		nur6012.setBedsoreZn(CommonUtils.parseDouble(item.getBedsoreZn()));
		nur6012.setBedsoreSize2(CommonUtils.parseDouble(item.getBedsoreSize2()));
		nur6012.setBedsoreSizeStart2(CommonUtils.parseDouble(item.getBedsoreSizeStart2()));
		nur6012.setBedsoreSizeFinish2(CommonUtils.parseDouble(item.getBedsoreSizeFinish2()));
		nur6012.setBedsorePoket2(CommonUtils.parseDouble(item.getBedsorePoket2()));
		nur6012.setBedsorePoketStart2(CommonUtils.parseDouble(item.getBedsorePoketStart2()));
		nur6012.setBedsorePoketFinish2(CommonUtils.parseDouble(item.getBedsorePoket2()));
		nur6012.setEndYn(item.getEndYn());
		nur6012.setExudationState1(item.getExudationState1());
		nur6012.setExudationState2(item.getExudationState2());
		nur6012.setBedsoreColor2(item.getBedsoreColor2());
		nur6012.setBedsoreColor3(item.getBedsoreColor3());
		nur6012.setBedsoreColor4(item.getBedsoreColor4());
		nur6012.setFirstSayu(item.getFirstSayu());
		nur6012.setLastSayu(item.getLastSayu());
		nur6012.setYokchangDeep(item.getYokchangDeep());
		nur6012.setSamchulYang(item.getSamchulYang());
		nur6012.setYokchangSize(item.getYokchangSize());
		nur6012.setYokchangSizeStart(CommonUtils.parseDouble(item.getYokchangSizeStart()));
		nur6012.setYokchangSizeEnd(CommonUtils.parseDouble(item.getYokchangSizeEnd()));
		nur6012.setYokchangGamyum(item.getYokchangGamyum());
		nur6012.setYukajojik(item.getYukajojik());
		nur6012.setGaesajojik(item.getGaesajojik());
		nur6012.setPocketGubun(item.getPocketGubun());
		nur6012.setPocketSizeStart(CommonUtils.parseDouble(item.getPocketSizeStart()));
		nur6012.setPocketSizeEnd(CommonUtils.parseDouble(item.getPocketSizeEnd()));
		nur6012.setYokchangStage(item.getYokchangStage());
		nur6012.setTotalCount(CommonUtils.parseDouble(item.getTotalCount()));
		nur6012.setYungyangSiksaGubun(item.getYungyangSiksaGubun());
		nur6012.setYungyangSiksaYang(CommonUtils.parseDouble(item.getYungyangSiksaYang()));
		nur6012.setYungyangSiksaPercent(CommonUtils.parseDouble(item.getYungyangSiksaPercent()));
		nur6012.setYungyangSuaekYn(item.getYungyangSuaekYn());
		nur6012.setYungyangSuaekYang(CommonUtils.parseDouble(item.getYungyangSuaekYang()));
		nur6012.setChuchiText(item.getChuchiText());
		nur6012.setYokchangHb(CommonUtils.parseDouble(item.getYokchangHb()));
		nur6012.setYokchangAlb(CommonUtils.parseDouble(item.getYokchangAlb()));
		nur6012.setYokchangTp(CommonUtils.parseDouble(item.getYokchangTp()));
		
		nur6012Repository.save(nur6012);
		
		return true;
	}
	
	private boolean insertNur6014(NuriModelProto.NUR6011U01grdImageInfo item, String hospCode, String userId, String fileName){
		Double nextSeq = nur6014Repository.getNextSeq(hospCode, item.getBunho(), item.getFromDate(), item.getBuwiGubun(), item.getAssessorDate());
		Nur6014 nur6014 = new Nur6014();
		
		nur6014.setSysDate(new Date());
		nur6014.setSysId(userId);
		nur6014.setUpdDate(new Date());
		nur6014.setUpdId(userId);
		nur6014.setHospCode(hospCode);
		nur6014.setBunho(item.getBunho());
		
		nur6014.setFromDate(DateUtil.toDate(item.getFromDate(), DateUtil.PATTERN_YYMMDD_BLANK));
		nur6014.setBedsoreBuwi(item.getBuwiGubun());
		nur6014.setAssessorDate(DateUtil.toDate(item.getAssessorDate(), DateUtil.PATTERN_YYMMDD_BLANK));
		nur6014.setSeq(nextSeq);
		nur6014.setBedsoreBuwiImage(item.getImagePath());
		
		nur6014Repository.save(nur6014);		
		return true;
	}
}
