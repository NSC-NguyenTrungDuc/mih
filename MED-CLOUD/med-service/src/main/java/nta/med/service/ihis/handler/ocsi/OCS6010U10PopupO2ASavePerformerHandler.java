package nta.med.service.ihis.handler.ocsi;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2015;
import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur0111Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.ocsi.DtMarumeKeyInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupO2ASavePerformerRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupO2ASavePerformerHandler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupO2ASavePerformerRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PopupO2ASavePerformerHandler.class);
	
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Resource
	private Nur0111Repository nur0111Repository; 
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupO2ASavePerformerRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		String directCode = request.getMdirectCode();
		Double pkocs2005 = CommonUtils.parseDouble(request.getMpkocs2005());
		List<OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info> grdocs2015 = request.getGrdocs2015List();
		List<OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info> grdocs2016 = request.getGrdocs2016List();
		
		response = handleGrdocs2015Deleted(hospCode, directCode, grdocs2015);
		if(!response.getResult()){
			LOGGER.info(String.format("Process grdocs2015 fail in DETETED hosp_code = %s", hospCode));
			return response.build();
		}
		
		response = handleGrdocs2015(hospCode, userId, pkocs2005, directCode, grdocs2015, grdocs2016);
		if(!response.getResult()){
			LOGGER.info(String.format("Process grdocs2015 & grdocs2016 fail hosp_code = %s", hospCode));
			return response.build();
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private UpdateResponse.Builder handleGrdocs2015Deleted(String hospCode, String directCode, List<OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info> grdocs2015){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		for (OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info info : grdocs2015) {
			if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				if (!StringUtils.isEmpty(info.getActDate()) && !StringUtils.isEmpty(info.getStartTime())
						&& !StringUtils.isEmpty(info.getEndDate()) && !StringUtils.isEmpty(info.getEndTime())) {
					
					// Execute procedure PR_OCSI_IS_JISI_DATETIME
					CommonProcResultInfo pResult = ocs2015Repository.callPrOcsiIsJisiDateime(hospCode, "D", "O2"
							, info.getBunho()
							, CommonUtils.parseDouble(info.getFkinp1001())
							, DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD)
							, info.getStartTime()
							, DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD)
							, info.getEndTime()
							, info.getActId());

					if(!"T".equals(pResult.getStrResult1())){
						LOGGER.info(String.format("Execute PR_OCSI_IS_JISI_DATETIME <D/O2> fail, hosp_code = %s, Err = %s", hospCode, pResult.getStrResult1()));
						response.setResult(false);
						return response;
					}
				}
				
				// Execute procedure PR_OCSI_MARUME_IUD
				CommonProcResultInfo pResultMarume = ocs2015Repository.callPrOcsiMarumeIud(hospCode, "DELETE", CommonUtils.parseDouble(info.getPkocs2015()));
				if(!"1".equals(pResultMarume.getStrResult1())){
					LOGGER.info(String.format("Execute PR_OCSI_MARUME_IUD DELETE fail, hosp_code = %s, pkocs2015= %s, Err = %s",
									hospCode, info.getPkocs2015(),pResultMarume.getStrResult1() == null ? "NULL" : pResultMarume.getStrResult1()));
					response.setResult(false);
					return response;
				}
				
				String sansoOrderCode = nur0111Repository.getSansoOrderCode(hospCode, directCode);
				List<DtMarumeKeyInfo> lstMarumeKey = ocs2003Repository.getDtMarumeKeyInfo(hospCode
																	, info.getBunho()
																	, CommonUtils.parseDouble(info.getFkinp1001())
																	, "D4"
																	, DateUtil.toDate(info.getActDate()
																	, DateUtil.PATTERN_YYMMDD), sansoOrderCode);
				
				// delete OCS2003
				ocs2003Repository.deleteOCS2003ByHospCodePkocs2015(hospCode, CommonUtils.parseDouble(info.getPkocs2015()));
				
				// delete OCS2015
				ocs2015Repository.deleteOcs2015InOCS6010Ext(hospCode, CommonUtils.parseDouble(info.getPkocs2015()));
				
				// delete OCS2016
				ocs2016Repository.deleteOcs2016InOCS6010(hospCode, CommonUtils.parseDouble(info.getPkocs2015()));
				
				// delete OCS2003
				String strX = ocs2015Repository.getXOCS6010U10PopupO2ASavePerformer(hospCode
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001())
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getPkSeq())
						, DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD));
				
				if (StringUtils.isEmpty(strX) && !StringUtils.isEmpty(sansoOrderCode)
						&& !CollectionUtils.isEmpty(lstMarumeKey)) {
					for (DtMarumeKeyInfo dt : lstMarumeKey) {
						ocs2003Repository.deleteOCS0103U13SaveLayout(hospCode, dt.getPkocs2003());
					}
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder handleGrdocs2015(String hospCode, String userId, Double fkocs2005, String directCode,
			List<OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info> grdocs2015,
			List<OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info> grdocs2016) {
		
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		for (OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info info : grdocs2015) {
			Date endDate = DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD);
			Date actDate = DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD);
			int processDays = DateUtil.getDateDiff(actDate, endDate == null ? actDate : endDate) + 1;
			
			String startTime = info.getStartTime();
			String endTime = info.getEndTime();
			List<Double> listPkocs2015 = new ArrayList<>();
			
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				for (int i = 1; i <= processDays; i++) {
					Double pkocs2015 = CommonUtils.parseDouble(info.getPkocs2015());
					actDate = DateUtil.increaseDate(DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD), i-1);
					
					if (processDays > 1)
						endDate = actDate;
					
					if(i == 1){
						if(processDays > 1) endTime = "2359";
					}
					else if(i != 1 && i!= processDays){
						startTime = "0000";
						endTime = "2359";
						String strSeq = commonRepository.getNextVal("OCS2015_SEQ");
						pkocs2015 = CommonUtils.parseDouble(strSeq);
					}
					else if(i == processDays){
						startTime = "0000";
						endTime = info.getEndTime();
						String strSeq = commonRepository.getNextVal("OCS2015_SEQ");
						pkocs2015 = CommonUtils.parseDouble(strSeq);
					}
					
					// Execute procedure PR_OCSI_IS_JISI_DATETIME
					if(actDate != null && !StringUtils.isEmpty(startTime) && endDate != null && !StringUtils.isEmpty(endTime)){
						CommonProcResultInfo pResult = ocs2015Repository.callPrOcsiIsJisiDateime(hospCode, "I", "O2"
								, info.getBunho()
								, CommonUtils.parseDouble(info.getFkinp1001())
								, actDate
								, startTime
								, endDate
								, endTime
								, info.getActId());

						if(!"T".equals(pResult.getStrResult1())){
							LOGGER.info(String.format("Execute PR_OCSI_IS_JISI_DATETIME <I/O2> fail, hosp_code = %s, Err = %s", hospCode, pResult.getStrResult1()));
							response.setResult(false);
							return response;
						}
					}
					
					// Insert OCS2015
					Double ocs2015seq = ocs2015Repository.getOCS6010U10frmARActingSeqOCS2015(hospCode, info.getBunho(), info.getFkinp1001(), info.getOrderDate(), info.getInputGubun(), info.getPkSeq());
					Ocs2015 ocs2015 = insertOcs2015(hospCode, userId, ocs2015seq, actDate, pkocs2015, fkocs2005, startTime, endTime, endDate, info);
					if(ocs2015 == null || ocs2015.getId() == null){
						LOGGER.error(String.format("Insert OCS2015 fail, hosp_code = %s", hospCode));
						response.setResult(false);
						return response;
					}
					
					// aList.Add(BindVar2015["f_pkocs2015"].VarValue);
					listPkocs2015.add(pkocs2015);
					
					// Handle Grid OCS2016
					boolean saveOcs2016Result = handleGrdOcs2016CaseAddedOcs2015(hospCode, userId, pkocs2015, grdocs2016);
					if(!saveOcs2016Result){
						LOGGER.info(String.format("Save OCS2016 <CASE ADDED> fail hosp_code = %s", hospCode));
						response.setResult(false);
						return response;
					}
					
					// Execute procedure PR_OCS_DIRECT_ACTING_O2
					CommonProcResultInfo pResult =ocs6010Repository.callPrOcsDirectActingO2(hospCode
							, info.getBunho()
							, CommonUtils.parseDouble(info.getFkinp1001())
							, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
							, info.getInputGubun()
							, CommonUtils.parseDouble(info.getPkSeq())
							, actDate
							, ocs2015seq
							, info.getStartTime()
							, info.getEndTime()
							, info.getActId()
							, CommonUtils.parseDouble(info.getSuryang())
							, pkocs2015);
					
					if(!"0".equals(pResult.getStrResult2())){
						LOGGER.info(String.format("Execute PR_OCS_DIRECT_ACTING_O2 <CASE ADDED> fail: hosp_code = %s, IO_MSG = %s, IO_FLAG = %s"
								, hospCode, pResult.getStrResult1() == null ? "null" : pResult.getStrResult1(), pResult.getStrResult2() == null ? "null" : pResult.getStrResult2()));
						response.setResult(false);
						return response;
					}
				}
				
				// Execute PR_OCSI_MARUME_IUD for each pkocs2015 is inserted
				if(!executePrOcsiMarumeIud(hospCode, "INSERT", listPkocs2015)){
					LOGGER.info(String.format("PR_OCSI_MARUME_IUD for list Pkocs2015 fail, hosp_code = %s", hospCode));
					response.setResult(false);
					return response;
				}
				
			} // End case ADDED
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				for (int i = 1; i <= processDays; i++) {
					Double pkocs2015 = CommonUtils.parseDouble(info.getPkocs2015());
					actDate = DateUtil.increaseDate(DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD), i-1);
					
					if(processDays > 1) endDate = actDate;
					
					if(i == 1){
						if(processDays > 1) endTime = "2359";
					}
					else if(i != 1 && i!= processDays){
						startTime = "0000";
						endTime = "2359";
						String strSeq = commonRepository.getNextVal("OCS2015_SEQ");
						pkocs2015 = CommonUtils.parseDouble(strSeq);
					}
					else if(i == processDays){
						startTime = "0000";
						endTime = info.getEndTime();
						String strSeq = commonRepository.getNextVal("OCS2015_SEQ");
						pkocs2015 = CommonUtils.parseDouble(strSeq);
					}
					
					if(processDays > 1){
						endDate = actDate;
					}
					
					// Execute PR_OCSI_IS_JISI_DATETIME
					if(actDate != null && !StringUtils.isEmpty(startTime) && endDate != null && !StringUtils.isEmpty(endTime)){
						CommonProcResultInfo pResult = ocs2015Repository.callPrOcsiIsJisiDateime(hospCode, "I", "O2"
								, info.getBunho()
								, CommonUtils.parseDouble(info.getFkinp1001())
								, actDate
								, startTime
								, endDate
								, endTime
								, info.getActId());

						if(!"T".equals(pResult.getStrResult1())){
							LOGGER.info(String.format("Execute PR_OCSI_IS_JISI_DATETIME <I/O2 MODIFIED> fail, hosp_code = %s, Err = %s", hospCode, pResult.getStrResult1()));
							response.setResult(false);
							return response;
						}
					}
					
					if(i == 1){
						// update OCS2015
						ocs2015Repository.updateOcs2015InOCS6010U10frmARActingSave(hospCode
								, pkocs2015
								, info.getActId()
								, actDate
								, actDate == null ? null : info.getActId()
								, ""	
								, CommonUtils.parseDouble(info.getSuryang())
								, null	//CommonUtils.parseDouble(info.getDv())
								, null	//CommonUtils.parseDouble(info.getChangeQty())
								, null	//CommonUtils.parseDouble(info.getFio2())
								, startTime
								, endTime
								, endDate);
						
						listPkocs2015.add(pkocs2015);
						
						if(!StringUtils.isEmpty(info.getEndTime())){
							// Execute procedure PR_OCS_DIRECT_ACTING_O2
							CommonProcResultInfo pResult =ocs6010Repository.callPrOcsDirectActingO2(hospCode
									, info.getBunho()
									, CommonUtils.parseDouble(info.getFkinp1001())
									, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
									, info.getInputGubun()
									, CommonUtils.parseDouble(info.getPkSeq())
									, actDate
									, CommonUtils.parseDouble(info.getSeq())
									, info.getStartTime()
									, info.getEndTime()
									, info.getActId()
									, CommonUtils.parseDouble(info.getSuryang())
									, pkocs2015);
							
							if(!"0".equals(pResult.getStrResult2())){
								LOGGER.info(String.format("Execute PR_OCS_DIRECT_ACTING_O2 <CASE MODIFIED> fail: hosp_code = %s, IO_MSG = %s, IO_FLAG = %s"
										, hospCode, pResult.getStrResult1() == null ? "null" : pResult.getStrResult1(), pResult.getStrResult2() == null ? "null" : pResult.getStrResult2()));
								response.setResult(false);
								return response;
							}
						}
					}else {
						double ocs2015seq = ocs2015Repository.getOCS6010U10frmARActingSeqOCS2015(hospCode,
								info.getBunho(), info.getFkinp1001(), info.getOrderDate(), info.getInputGubun(),info.getPkSeq());
						Ocs2015 ocs2015 = insertOcs2015(hospCode, userId, ocs2015seq, actDate, pkocs2015, fkocs2005, startTime, endTime, endDate, info);
						if(ocs2015 == null){
							LOGGER.info(String.format("Insert OCS2015 fail hosp_code = %s", hospCode));
							response.setResult(false);
							return response;
						}
						
						listPkocs2015.add(pkocs2015);
						
						boolean saveOcs2016Result = handleGrdOcs2016CaseModifiedOcs2015(hospCode, userId, pkocs2015, grdocs2016, i);
						if(!saveOcs2016Result){
							LOGGER.info(String.format("Save OCS2016 <CASE MODIFIED> fail hosp_code = %s", hospCode));
							response.setResult(false);
							return response;
						}
						
						// Execute procedure PR_OCS_DIRECT_ACTING_O2
						CommonProcResultInfo pResult =ocs6010Repository.callPrOcsDirectActingO2(hospCode
								, info.getBunho()
								, CommonUtils.parseDouble(info.getFkinp1001())
								, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
								, info.getInputGubun()
								, CommonUtils.parseDouble(info.getPkSeq())
								, actDate
								, CommonUtils.parseDouble(info.getSeq())
								, info.getStartTime()
								, info.getEndTime()
								, info.getActId()
								, CommonUtils.parseDouble(info.getSuryang())
								, pkocs2015);
						
						if(!"0".equals(pResult.getStrResult2())){
							LOGGER.info(String.format("Execute PR_OCS_DIRECT_ACTING_O2 <CASE MODIFIED> fail: hosp_code = %s, IO_MSG = %s, IO_FLAG = %s"
									, hospCode, pResult.getStrResult1() == null ? "null" : pResult.getStrResult1(), pResult.getStrResult2() == null ? "null" : pResult.getStrResult2()));
							response.setResult(false);
							return response;
						}
					}
				}
				
				// Execute PR_OCSI_MARUME_IUD for each pkocs2015 is inserted
				if(!executePrOcsiMarumeIud(hospCode, "INSERT", listPkocs2015)){
					LOGGER.info(String.format("PR_OCSI_MARUME_IUD <CASE MODIFIED> for list Pkocs2015 fail, hosp_code = %s", hospCode));
					response.setResult(false);
					return response;
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private Ocs2015 insertOcs2015(String hospCode, String userId, Double seq, Date actDate, Double pkocs2015, Double fkocs2005, String startTime, String endTime, Date endDate, OcsiModelProto.OCS6010U10PopupO2AgrdOCS2015Info info){
		Ocs2015 ocs2015 = new Ocs2015();
		Date sysDate = Calendar.getInstance().getTime();
		
		ocs2015.setSysDate(sysDate);
		ocs2015.setSysId(userId);
		ocs2015.setUpdDate(sysDate);
		ocs2015.setBunho(info.getBunho());
		ocs2015.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2015.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setInputGubun(info.getInputGubun());
		ocs2015.setInputId(info.getInputId());
		ocs2015.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
		ocs2015.setSeq(seq);			// OCS2015_SEQ
		ocs2015.setInputGwa(info.getInputGwa());
		ocs2015.setInputDoctor(info.getInputDoctor());
		ocs2015.setDrtDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActDate(actDate);
		ocs2015.setActId(actDate == null ? null : info.getActId());
		ocs2015.setActResultText("");
		ocs2015.setHospCode(hospCode);
		ocs2015.setPkocs2015(pkocs2015);
		ocs2015.setDv(null);			
		ocs2015.setChangeQty(null);		
		ocs2015.setFio2(null);			
		ocs2015.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
		ocs2015.setStartTime(startTime);
		ocs2015.setEndTime(endTime);
		ocs2015.setEndDate(endDate);
		ocs2015.setFkocs2005(fkocs2005);
		
		ocs2015Repository.save(ocs2015);
		return ocs2015;
	}
	

	private boolean handleGrdOcs2016CaseAddedOcs2015(String hospCode, String userId, Double pkocs2015, List<OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info> lstOcs2016){
		for (OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info info : lstOcs2016) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				String strSeq = ocs2016Repository.getOCS6010U10frmARActingSeqOCS2016(hospCode, pkocs2015);
				Double seq = CommonUtils.parseDouble(strSeq);
				
				String strPkocs2016 = commonRepository.getNextVal("OCS2016_SEQ");
				Double pkocs2016 = CommonUtils.parseDouble(strPkocs2016);
				
				Ocs2016 ocs2016 = new Ocs2016();
				Date sysDate = Calendar.getInstance().getTime();
				ocs2016.setSysDate(sysDate);
				ocs2016.setSysId(userId);
				ocs2016.setUpdDate(sysDate);
				ocs2016.setUpdId(userId);
				ocs2016.setHospCode(hospCode);
				ocs2016.setFkocs2015(pkocs2015);
				ocs2016.setPkocs2016(pkocs2016);
				ocs2016.setHangmogCode(info.getHangmogCode());
				ocs2016.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
				ocs2016.setBomYn(info.getBomYn());
				ocs2016.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
				ocs2016.setSeq(seq);
			
				ocs2016Repository.save(ocs2016);
				if(ocs2016 == null || ocs2016.getId() == null){
					LOGGER.info(String.format("Insert OCS2016 fail, hosp_code = %s, pkocs2015 = %s", hospCode, pkocs2015));
					return false;
				}
			}
		}
		
		return true;
	}
	
	
	private boolean handleGrdOcs2016CaseModifiedOcs2015(String hospCode, String userId, Double pkocs2015, List<OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info> lstOcs2016, int i){
		for (OcsiModelProto.OCS6010U10frmARActinggrdOCS2016Info info : lstOcs2016) {
			Double seq = CommonUtils.parseDouble(info.getSeq());
			
			if(i != 1){
				String strSeq = ocs2016Repository.getOCS6010U10frmARActingSeqOCS2016(hospCode, pkocs2015);
				seq = CommonUtils.parseDouble(strSeq);
			}
			
			String strPkocs2016 = commonRepository.getNextVal("OCS2016_SEQ");
			Double pkocs2016 = CommonUtils.parseDouble(strPkocs2016);
			
			Ocs2016 ocs2016 = new Ocs2016();
			Date sysDate = Calendar.getInstance().getTime();
			ocs2016.setSysDate(sysDate);
			ocs2016.setSysId(userId);
			ocs2016.setUpdDate(sysDate);
			ocs2016.setUpdId(userId);
			ocs2016.setHospCode(hospCode);
			ocs2016.setFkocs2015(pkocs2015);
			ocs2016.setPkocs2016(pkocs2016);
			ocs2016.setHangmogCode(info.getHangmogCode());
			ocs2016.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
			ocs2016.setBomYn(info.getBomYn());
			ocs2016.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
			ocs2016.setSeq(seq);
		
			ocs2016Repository.save(ocs2016);
			if(ocs2016 == null || ocs2016.getId() == null){
				LOGGER.info(String.format("Insert OCS2016 fail, hosp_code = %s, pkocs2015 = %s", hospCode, pkocs2015));
				return false;
			}
		}
		
		return true;
	}
	
	private boolean executePrOcsiMarumeIud(String hospCode, String gubun, List<Double> listPkocs2015){
		if(CollectionUtils.isEmpty(listPkocs2015)) return true;
		
		for (Double pkocs2015 : listPkocs2015) {
			CommonProcResultInfo pResultMarumeInsert = ocs2015Repository.callPrOcsiMarumeIud(hospCode, gubun, pkocs2015);
			if(!"1".equals(pResultMarumeInsert.getStrResult1())){
				LOGGER.info(String.format("ExecutePrOcsiMarumeIud PR_OCSI_MARUME_IUD INSERT fail, hosp_code = %s, pkocs2015 =%s, Err = %s", hospCode,
						pkocs2015, pResultMarumeInsert.getStrResult1() == null ? "NULL": pResultMarumeInsert.getStrResult1()));
				return false;
			}
		}
		
		return true;
	}

	
}
