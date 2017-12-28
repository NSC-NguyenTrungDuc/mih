package nta.med.service.ihis.handler.ocsi;

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

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs2003;
import nta.med.core.domain.out.Outsang;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01SaveLayoutRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003P01SaveLayoutResponse;

@Service
@Scope("prototype")
public class OCS2003P01SaveLayoutHandler extends
		ScreenHandler<OcsiServiceProto.OCS2003P01SaveLayoutRequest, OcsiServiceProto.OCS2003P01SaveLayoutResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS2003P01SaveLayoutHandler.class);
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional
	public OCS2003P01SaveLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003P01SaveLayoutRequest request) throws Exception {
		OcsiServiceProto.OCS2003P01SaveLayoutResponse.Builder response = OcsiServiceProto.OCS2003P01SaveLayoutResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		//String saveTime = commonRepository.getSystemDateTime();
		
		List<OcsiModelProto.OCS2003P01GrdOutsangInfo> grdOutsangList  = request.getGrdOutsangListList();
		List<OcsiModelProto.OCS2003P01LayDeletedDataInfo> layDeletedList = request.getLayDeletedListList(); 
		List<OcsiModelProto.OCS2003P01LaySaveLayoutInfo> laySaveList = request.getLaySaveListList();
		
		String changeBeforeGwa = "";
		Integer deletedOrderCnt = 0;
		Integer insteadDeletedOrderCnt = 0;
		Integer insertedOrderCnt = 0;
		Integer insteadInsertedOrderCnt = 0;
		Integer updatedOrderCnt = 0; 
		Integer insteadUpdatedOrderCnt = 0;
		
		// handle OUTSANG list
		if(!CollectionUtils.isEmpty(grdOutsangList)){
			boolean iudOutsangResult = handleGrdOutsangList(hospCode, userId, grdOutsangList, changeBeforeGwa);
			if(!iudOutsangResult){
				LOGGER.info(String.format("Handle GrdOutsangList Fail, hosp_code = %s", hospCode));
				response.setSaveRes(false);
				throw new ExecutionException(response.build());
			}
			
			response.setChangeBeforeGwa(changeBeforeGwa);
		}
		
		// handle delete list
		if(!CollectionUtils.isEmpty(layDeletedList)){
			boolean delResult = handleLayDeletedList(hospCode, layDeletedList, deletedOrderCnt, insteadDeletedOrderCnt);
			if(!delResult){
				LOGGER.info(String.format("Handle LayDeletedList Fail, hosp_code = %s", hospCode));
				response.setSaveRes(false);
				throw new ExecutionException(response.build());
			}
			
			response.setDeletedOrderCnt(String.valueOf(deletedOrderCnt));
			response.setInsteadDeletedOrderCnt(String.valueOf(insteadDeletedOrderCnt));
		}

		// handle save list
		if(!CollectionUtils.isEmpty(laySaveList)){
			boolean saveResult = handleLaySaveList(hospCode, userId, laySaveList, request.getInputGubun(), request.getPostApproveYN(), insertedOrderCnt, insteadInsertedOrderCnt, updatedOrderCnt, insteadUpdatedOrderCnt);
			if(!saveResult){
				LOGGER.info(String.format("Handle LaySaveList Fail, hosp_code = %s", hospCode));
				response.setSaveRes(false);
				throw new ExecutionException(response.build());
			}
			
			response.setInsertedOrderCnt(String.valueOf(insertedOrderCnt));
			response.setInsteadInsertedOrderCnt(String.valueOf(insteadInsertedOrderCnt));
		}
		
		// call PR_OCS_APPLY_NDAY_ORDER
		String outputProc = ocs2003Repository.callPrOcsApplyNdayOrderOCS0103U13(hospCode, request.getBunhoProc(), DateUtil.toDate(request.getOrderDateProc(), DateUtil.PATTERN_YYMMDD));
		response.setOutputProc(outputProc);
		
		response.setSaveRes(true);
		return response.build();
	}
	
	private boolean handleGrdOutsangList(String hospCode, String userId, List<OcsiModelProto.OCS2003P01GrdOutsangInfo> grdOutsangList, String changeBeforeGwa){
		
		for (OcsiModelProto.OCS2003P01GrdOutsangInfo info : grdOutsangList) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Double pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,info.getBunho(),info.getGwa(),info.getIoGubun());
				pkSeq = pkSeq == null ? 1.0 : pkSeq;
				
				Double ser = outsangRepository.getOUTSANGU00Ser(hospCode, info.getBunho());
				ser = ser == null ? 1.0 : ser;
				
				String dupCheck = outsangRepository.checkOcsoOCS1003P01SangDupCheck(hospCode
						, info.getIoGubun()
						, info.getGwa()
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001()) 
						, info.getSangCode()
						, info.getSangName()
						, info.getPostModifierName()
						, info.getPreModifierName()
						, info.getSangStartDate()
						, info.getSangEndDate()
						, info.getSangJindanDate()
						, info.getDataGubun()
						, info.getJuSangYn());
				
				if("Y".equals(dupCheck)){
					LOGGER.info(String.format("Duplicate OUTSANG INSERT hosp_code = %s, io_gubun= %s, gwa = %s, bunho = %s, fkinp1001 = %s, sang_code = %s, sang_name = %s, post_modifier_name = %s, pre_modifier_name = %s, sang_start_date = %s, sang_end_date = %s, sang_jindan_date = %s, data_gubun = %s, ju_sang_yn = %s",
							hospCode, info.getIoGubun(), info.getGwa(), info.getBunho(), info.getFkinp1001(),info.getSangCode(), info.getSangName(), info.getPostModifierName(),
							info.getPreModifierName(), info.getSangStartDate(), info.getSangEndDate(),info.getSangJindanDate(), info.getDataGubun(), info.getJuSangYn()));
					return false;
				}
				
				Outsang outsang = insertOutsang(hospCode, userId, info, pkSeq, ser);
				if(outsang == null || outsang.getId() == null){
					LOGGER.info(String.format("Insert OUTSANG was fail, hosp_code = %s", hospCode));
					return false;
				}
			} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				Double pkoutsang = CommonUtils.parseDouble(info.getPkoutsang());
				changeBeforeGwa = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
				Double changeBeforePkseq = CommonUtils.parseDouble(info.getPkSeq());
				
				Double ser = StringUtils.isEmpty(info.getSer()) ? 0.0 : CommonUtils.parseDouble(info.getSer());
				Double pkSeq = StringUtils.isEmpty(info.getPkSeq()) ? 0.0 : CommonUtils.parseDouble(info.getPkSeq());
				
				if("%".equals(changeBeforeGwa)){
					pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,info.getBunho(),info.getGwa(),info.getIoGubun());
					pkSeq = pkSeq == null ? 1.0 : pkSeq;
					
					ser = outsangRepository.getOUTSANGU00Ser(hospCode, info.getBunho());
					ser = ser == null ? 1.0 : ser;
				}
				
				String dupCheck = outsangRepository.checkOcsoOCS1003P01SangDupCheck(hospCode
						, info.getIoGubun()
						, info.getGwa()
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001()) 
						, info.getSangCode()
						, info.getSangName()
						, info.getPostModifierName()
						, info.getPreModifierName()
						, info.getSangStartDate()
						, info.getSangEndDate()
						, info.getSangJindanDate()
						, "U"
						, info.getJuSangYn());
				
				if("Y".equals(dupCheck)){
					LOGGER.info(String.format("Duplicate OUTSANG UPDATE hosp_code = %s, io_gubun= %s, gwa = %s, bunho = %s, fkinp1001 = %s, sang_code = %s, sang_name = %s, post_modifier_name = %s, pre_modifier_name = %s, sang_start_date = %s, sang_end_date = %s, sang_jindan_date = %s, data_gubun = %s, ju_sang_yn = %s",
							hospCode, info.getIoGubun(), info.getGwa(), info.getBunho(), info.getFkinp1001(),info.getSangCode(), info.getSangName(), info.getPostModifierName(),
							info.getPreModifierName(), info.getSangStartDate(), info.getSangEndDate(),info.getSangJindanDate(), "U", info.getJuSangYn()));
					return false;
				}
				
				int rowUpdated = updateOutSang(hospCode, userId, info, pkSeq, ser, changeBeforeGwa, changeBeforePkseq, "U");
				if(rowUpdated <= 0){
					LOGGER.info(String.format("Update OUTSANG was fail, hosp_code = %s", hospCode));
					return false;
				}
			}  else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				String ifDataSendYn = outsangRepository.getIfDataSendYn(hospCode, info.getBunho(), info.getGwa(), info.getIoGubun(), CommonUtils.parseDouble(info.getPkSeq()));
				if(info.getDataGubun().equalsIgnoreCase("I") && ifDataSendYn.equalsIgnoreCase("N")){
					int rowDeleted = outsangRepository.deleteOUTSANGU00Transaction(info.getBunho(),info.getGwa(),info.getIoGubun(),CommonUtils.parseDouble(info.getPkSeq()),hospCode);
					if(rowDeleted <= 0){
						LOGGER.info(String.format("Delete OUTSANG was fail, hosp_code = %s", hospCode));
						return false;
					}
				} else {
					Double pkoutsang = CommonUtils.parseDouble(info.getPkoutsang());
					changeBeforeGwa = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
					Double changeBeforePkseq = CommonUtils.parseDouble(info.getPkSeq());
					
					/*Double ser = CommonUtils.parseDouble(info.getSer());
					Double pkSeq = CommonUtils.parseDouble(info.getPkSeq());
					if("%".equals(changeBeforeGwa)){
						pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,info.getBunho(),info.getGwa(),info.getIoGubun());
						pkSeq = pkSeq == null ? 1.0 : pkSeq;
						
						ser = outsangRepository.getOUTSANGU00Ser(hospCode, info.getBunho());
						ser = ser == null ? 1.0 : ser;
					}*/

					int rowUpdated = updateOutSangIgnoreSeq(hospCode, userId, info, changeBeforeGwa, changeBeforePkseq, "D");
					if(rowUpdated <= 0){
						LOGGER.info(String.format("Delete OUTSANG was fail(data_gubun = D), hosp_code = %s", hospCode));
						return false;
					}
				}
			}
		}
		
		return true;
	}
	
	private boolean handleLayDeletedList(String hospCode, List<OcsiModelProto.OCS2003P01LayDeletedDataInfo> layDeletedList, int deletedOrderCnt, int insteadDeletedOrderCnt){
		
		for (OcsiModelProto.OCS2003P01LayDeletedDataInfo info : layDeletedList) {
			// Call PR_OCS_UPDATE_DC_YN
			if(!StringUtils.isEmpty(info.getSourceOrdKey())){
				String ioFlg = ocs1003Repository.callPrOcsUpdateDcYn(hospCode, "I",CommonUtils.parseDouble(info.getSourceOrdKey()));
				if(!"0".equals(ioFlg)){
					LOGGER.info(String.format("Call procedure PR_OCS_UPDATE_DC_YN fail, hosp_code = %s, source_ord_key = %s, result = %s", hospCode, info.getSourceOrdKey(), (ioFlg == null ? "" : ioFlg)));
					return false;
				}
				
				LOGGER.info(String.format("Call procedure PR_OCS_UPDATE_DC_YN, hosp_code = %s, source_ord_key = %s, result = %s", hospCode, info.getSourceOrdKey(), ioFlg));
			}
			
			// Call PR_OCS_DELETE_NDAY_ORDER
			if("Y".equals(info.getNdayYn())){
				String ioFlg = ocs2003Repository.callPrOcsDeleteNdayOrder(hospCode,CommonUtils.parseDouble(info.getPkocskey()));
				if(!"0".equals(ioFlg)){
					LOGGER.info(String.format("Call procedure PR_OCS_DELETE_NDAY_ORDER fail, hosp_code = %s, pkocs_key = %s, result = %s", hospCode, info.getPkocskey(), (ioFlg == null ? "" : ioFlg)));
					return false;
				}
				
				LOGGER.info(String.format("Call procedure PR_OCS_DELETE_NDAY_ORDER, hosp_code = %s, pkocs_key = %s, result = %s", hospCode, info.getPkocskey(), ioFlg));
			}
			
			// delete OCS2003
			int rowDeleted = ocs2003Repository.deleteOCS0103U13SaveLayout(hospCode, CommonUtils.parseDouble(info.getPkocskey()));
			if(rowDeleted <= 0){
				LOGGER.info(String.format("Delete OCS2003 fail, hosp_code = %s, pkocskey = %s", hospCode, info.getPkocskey()));
				return false;
			}
			
			if(!StringUtils.isEmpty(info.getInputGubun()) && !StringUtils.isEmpty(info.getOrderGubun()) 
					&& ("4".equals(info.getInputGubun().substring(1, 2)) || "7".equals(info.getInputGubun().substring(1, 2)))
					&& (	"B".equals(info.getOrderGubun().substring(1, 2))
						||	"C".equals(info.getOrderGubun().substring(1, 2))
						||	"D".equals(info.getOrderGubun().substring(1, 2)))){
				
				deletedOrderCnt ++;
			} 
			
			if("Y".equals(info.getInsteadYn())){
				insteadDeletedOrderCnt ++;
			}
			
		}
		
		return true;
	}
	
	private boolean handleLaySaveList(String hospCode, String userId,
			List<OcsiModelProto.OCS2003P01LaySaveLayoutInfo> laySaveList, String inputGubun, String postApproveYN,
			int insertedOrderCnt, int insteadInsertedOrderCnt, int updatedOrderCnt, int insteadUpdatedOrderCnt) {
		
		Date sysDate = new Date();
		
		for (OcsiModelProto.OCS2003P01LaySaveLayoutInfo info : laySaveList) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				String strOcskey = commonRepository.getNextVal("OCSKEY_SEQ");
				Double pkOcskey = CommonUtils.parseDouble(strOcskey);
				
				Double seq=null;
				if(StringUtils.isEmpty(info.getSeq())){
					seq=ocs2003Repository.getMaxSeqOCS0103U13SaveLayout(hospCode,info.getBunho(),CommonUtils.parseDouble(info.getInOutKey()),info.getOrderDate());
					if(seq == null) seq = 1.0;
				}
				
				String insteadYn = "N";
				String insteadId = null;
				String insteadDate = null;
				String insteadTime = null;
				
				if("CK".equals(inputGubun)){
					insteadYn = "Y";
					insteadId = userId;
					insteadDate = DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD);
					insteadTime = DateUtil.toString(sysDate, "HHmm");
				}
				
				Ocs2003 ocs2003 = insertOcs2003(hospCode, userId, sysDate, info, pkOcskey, seq, insteadYn, insteadId, DateUtil.toDate(insteadDate, DateUtil.PATTERN_YYMMDD), insteadTime);
				if(ocs2003 == null || ocs2003.getId() == null){
					LOGGER.info(String.format("Insert OCS2003 fail, hosp_code = %s", hospCode));
					return false;
				}
				
				if(!StringUtils.isEmpty(info.getInputGubun()) && !StringUtils.isEmpty(info.getOrderGubun()) 
						&& ("4".equals(info.getInputGubun().substring(1, 2)) || "7".equals(info.getInputGubun().substring(1, 2)))
						&& (	"B".equals(info.getOrderGubun().substring(1, 2))
							||	"C".equals(info.getOrderGubun().substring(1, 2))
							||	"D".equals(info.getOrderGubun().substring(1, 2)))){
					
					insertedOrderCnt ++;
				} 
				
				if("Y".equals(insteadYn)){
					insteadInsertedOrderCnt ++;
				}
			} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				int rowUpdated = updateOcs2003(hospCode, userId, sysDate, info);
				if(rowUpdated <= 0){
					LOGGER.info(String.format("Update OCS2003 fail, hosp_code = %s", hospCode));
					return false;
				}
				
				if(!StringUtils.isEmpty(info.getInputGubun()) && !StringUtils.isEmpty(info.getOrderGubun()) 
						&& ("4".equals(info.getInputGubun().substring(1, 2)) || "7".equals(info.getInputGubun().substring(1, 2)))
						&& (	"B".equals(info.getOrderGubun().substring(1, 2))
							||	"C".equals(info.getOrderGubun().substring(1, 2))
							||	"D".equals(info.getOrderGubun().substring(1, 2)))){
					
					updatedOrderCnt ++;
				} 
				
				if("Y".equals(info.getInsteadYn())){
					insteadUpdatedOrderCnt ++;
				}
			}
		}
		
		return true;
	}
	
	private Outsang insertOutsang(String hospCode, String userId, OcsiModelProto.OCS2003P01GrdOutsangInfo info, double pkSeq, double ser){
		Outsang outsang = new Outsang();
		Date sysDate = new Date();
		
		outsang.setSysDate(sysDate);
		outsang.setSysId(userId);
		outsang.setUpdDate(sysDate);
		outsang.setBunho(info.getBunho());
		outsang.setGwa(info.getGwa());
		outsang.setIoGubun(info.getIoGubun());
		outsang.setPkSeq(pkSeq);
		outsang.setNaewonDate(DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
		outsang.setDoctor(info.getLastDoctor());
		outsang.setNaewonType(null);	
		outsang.setJubsuNo(CommonUtils.parseDouble(info.getJubsuNo()));
		outsang.setLastNaewonDate(DateUtil.toDate(info.getLastNaewonDate(), DateUtil.PATTERN_YYMMDD));
		outsang.setLastDoctor(info.getLastDoctor());
		outsang.setLastNaewonType(info.getLastNaewonType());
		outsang.setLastJubsuNo(CommonUtils.parseDouble(info.getLastJubsuNo()));
		outsang.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		outsang.setInputId(info.getInputId());
		outsang.setSer(ser);
		outsang.setSangCode(info.getSangCode());
		outsang.setJuSangYn(info.getJuSangYn());
		outsang.setSangName(info.getSangName());
		outsang.setSangStartDate(DateUtil.toDate(info.getSangStartDate(), DateUtil.PATTERN_YYMMDD));
		outsang.setSangEndDate(DateUtil.toDate(info.getSangEndDate(), DateUtil.PATTERN_YYMMDD));
		outsang.setSangEndSayu(info.getSangEndSayu());
		outsang.setPreModifier1(info.getPreModifier1());
		outsang.setPreModifier2(info.getPreModifier2());
		outsang.setPreModifier3(info.getPreModifier3());
		outsang.setPreModifier4(info.getPreModifier4());
		outsang.setPreModifier5(info.getPreModifier5());
		outsang.setPreModifier6(info.getPreModifier6());
		outsang.setPreModifier7(info.getPreModifier7());
		outsang.setPreModifier8(info.getPreModifier8());
		outsang.setPreModifier9(info.getPreModifier9());
		outsang.setPreModifier10(info.getPreModifier10());
		outsang.setPreModifierName(info.getPreModifierName());
		outsang.setPostModifier1(info.getPostModifier1());
		outsang.setPostModifier2(info.getPostModifier2());
		outsang.setPostModifier3(info.getPostModifier3());
		outsang.setPostModifier4(info.getPostModifier4());
		outsang.setPostModifier5(info.getPostModifier5());
		outsang.setPostModifier6(info.getPostModifier6());
		outsang.setPostModifier7(info.getPostModifier7());
		outsang.setPostModifier8(info.getPostModifier8());
		outsang.setPostModifier9(info.getPostModifier9());
		outsang.setPostModifier10(info.getPostModifier10());
		outsang.setPostModifierName(info.getPostModifierName());
		outsang.setHospCode(hospCode);
		outsang.setUpdId(userId);
		outsang.setFkout1001(CommonUtils.parseDouble(info.getFkout1001()));
		outsang.setSangJindanDate(DateUtil.toDate(info.getSangJindanDate(), DateUtil.PATTERN_YYMMDD));
		outsang.setDataGubun("I");
		
		outsangRepository.save(outsang);
		return outsang;
	}
	
	private Integer updateOutSang(String hospCode, String userId, OcsiModelProto.OCS2003P01GrdOutsangInfo info, double pkSeq, double ser, String changeBeforeGwa, double changeBeforePkseq, String dataGubun){
		return outsangRepository.updateOcs2003P01Outsang(
				  info.getJuSangYn()
				, info.getSangName()
				, DateUtil.toDate(info.getSangStartDate(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(info.getSangEndDate(), DateUtil.PATTERN_YYMMDD)
				, info.getSangEndSayu()
				, info.getPreModifier1()
				, info.getPreModifier2()
				, info.getPreModifier3()
				, info.getPreModifier4()
				, info.getPreModifier5()
				, info.getPreModifier6()
				, info.getPreModifier7()
				, info.getPreModifier8()
				, info.getPreModifier9()
				, info.getPreModifier10()
				, info.getPreModifierName()
				, info.getPostModifier1()
				, info.getPostModifier2()
				, info.getPostModifier3()
				, info.getPostModifier4()
				, info.getPostModifier5()
				, info.getPostModifier6()
				, info.getPostModifier7()
				, info.getPostModifier8()
				, info.getPostModifier9()
				, info.getPostModifier10()
				, info.getPostModifierName()
				, userId
				, DateUtil.toDate(info.getSangJindanDate(), DateUtil.PATTERN_YYMMDD)
				, info.getGwa()
				, dataGubun
				, pkSeq
				, ser
				, hospCode
				, info.getBunho()
				, changeBeforeGwa
				, info.getIoGubun()
				, changeBeforePkseq);
	}
	
	private Integer updateOutSangIgnoreSeq(String hospCode, String userId, OcsiModelProto.OCS2003P01GrdOutsangInfo info, String changeBeforeGwa, double changeBeforePkseq, String dataGubun){
		return outsangRepository.updateOcs2003P01OutsangIgnoreSeq(
				  info.getJuSangYn()
				, info.getSangName()
				, DateUtil.toDate(info.getSangStartDate(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(info.getSangEndDate(), DateUtil.PATTERN_YYMMDD)
				, info.getSangEndSayu()
				, info.getPreModifier1()
				, info.getPreModifier2()
				, info.getPreModifier3()
				, info.getPreModifier4()
				, info.getPreModifier5()
				, info.getPreModifier6()
				, info.getPreModifier7()
				, info.getPreModifier8()
				, info.getPreModifier9()
				, info.getPreModifier10()
				, info.getPreModifierName()
				, info.getPostModifier1()
				, info.getPostModifier2()
				, info.getPostModifier3()
				, info.getPostModifier4()
				, info.getPostModifier5()
				, info.getPostModifier6()
				, info.getPostModifier7()
				, info.getPostModifier8()
				, info.getPostModifier9()
				, info.getPostModifier10()
				, info.getPostModifierName()
				, userId
				, DateUtil.toDate(info.getSangJindanDate(), DateUtil.PATTERN_YYMMDD)
				, info.getGwa()
				, dataGubun
				, hospCode
				, info.getBunho()
				, changeBeforeGwa
				, info.getIoGubun()
				, changeBeforePkseq);
	}
	
	private Ocs2003 insertOcs2003(String hospCode, String userId, Date sysDate, OcsiModelProto.OCS2003P01LaySaveLayoutInfo info, Double pkOcskey, Double seq, String insteadYn, String insteadId, Date insteadDate, String insteadTime){
		Ocs2003 ocs2003 = new Ocs2003();
		
		ocs2003.setSysDate(sysDate);
		ocs2003.setSysId(userId);
		ocs2003.setUpdDate(sysDate);
		ocs2003.setUpdId(userId);
		ocs2003.setHospCode(hospCode);
		ocs2003.setPkocs2003(pkOcskey);
		ocs2003.setBunho(info.getBunho());
		ocs2003.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setOrderTime(DateUtil.toString(sysDate, "HHmm"));
		ocs2003.setDoctor(info.getDoctor());
		ocs2003.setInputId(info.getInputId());
		ocs2003.setInputPart(info.getInputPart());
		ocs2003.setInputGubun(info.getInputGubun());
		ocs2003.setSeq(seq);
		ocs2003.setResident(info.getResident());
		ocs2003.setHangmogCode(info.getHangmogCode());
		ocs2003.setGroupSer(Double.valueOf(info.getGroupSer()));
		ocs2003.setSlipCode(info.getSlipCode());
		ocs2003.setNdayYn(info.getNdayYn());
		ocs2003.setOrderGubun(info.getOrderGubun());
		ocs2003.setSpecimenCode(info.getSpecimenCode());
		ocs2003.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
		ocs2003.setOrdDanui(info.getOrdDanui());
		ocs2003.setDvTime(info.getDvTime());
		ocs2003.setDv(CommonUtils.parseDouble(info.getDv()));
		ocs2003.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
		ocs2003.setJusa(info.getJusa());
		ocs2003.setBogyongCode(info.getBogyongCode());
		ocs2003.setEmergency(info.getEmergency());
		ocs2003.setJaeryoJundalYn(info.getJaeryoJundalYn());
		ocs2003.setJundalTable(info.getJundalTable());
		ocs2003.setJundalPart(info.getJundalPart());
		ocs2003.setMovePart(info.getMovePart());
		ocs2003.setMuhyo(info.getMuhyo());
		ocs2003.setPortableYn(info.getPortableYn());
		ocs2003.setAntiCancerYn("N");
		ocs2003.setPay(info.getPay());
		ocs2003.setReserDate(DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setReserTime(info.getReserTime());
		ocs2003.setDcYn(info.getDcYn());
		ocs2003.setDcGubun(info.getDcGubun());
		ocs2003.setBannabYn(info.getBannabYn());
		ocs2003.setBannabConfirm(info.getBannabConfirm());
		ocs2003.setActDoctor(info.getActDoctor());
		ocs2003.setActGwa(info.getActGwa());
		ocs2003.setActBuseo(info.getActBuseo());
		ocs2003.setOcsFlag(info.getOcsFlag());
		ocs2003.setSgCode(info.getSgCode());
		ocs2003.setSgYmd(DateUtil.toDate(info.getSgYmd(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setIoGubun(info.getIoGubun());
		ocs2003.setBichiYn(info.getBichiYn());
		ocs2003.setDrgBunho(CommonUtils.parseDouble(info.getDrgBunho()));
		ocs2003.setSubSusul(info.getSubSusul());
		ocs2003.setWonyoiOrderYn(info.getWonyoiOrderYn());
		ocs2003.setPowderYn(info.getPowderYn());
		ocs2003.setHopeDate(DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setHopeTime(info.getHopeTime());
		ocs2003.setDv1(CommonUtils.parseDouble(info.getDv1()));
		ocs2003.setDv2(CommonUtils.parseDouble(info.getDv2()));
		ocs2003.setDv3(CommonUtils.parseDouble(info.getDv3()));
		ocs2003.setDv4(CommonUtils.parseDouble(info.getDv4()));
		ocs2003.setDv5(CommonUtils.parseDouble(info.getDv5()));
		ocs2003.setDv6(CommonUtils.parseDouble(info.getDv6()));
		ocs2003.setDv7(CommonUtils.parseDouble(info.getDv7()));
		ocs2003.setDv8(CommonUtils.parseDouble(info.getDv8()));
		ocs2003.setMixGroup(info.getMixGroup());
		ocs2003.setOrderRemark(info.getOrderRemark());
		ocs2003.setNurseConfirmDate(DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setNurseConfirmTime(info.getNurseConfirmTime());
		ocs2003.setTelYn(info.getTelYn());
		ocs2003.setRegularYn(info.getRegularYn());
		ocs2003.setInputTab(info.getInputTab());
		ocs2003.setHubalChangeYn(info.getHubalChangeYn());
		ocs2003.setPharmacy(info.getPharmacy());
		ocs2003.setInputDoctor(info.getInputDoctor());
		ocs2003.setJusaSpdGubun(info.getJusaSpdGubun());
		ocs2003.setDrgPackYn(info.getDrgPackYn());
		ocs2003.setSortFkocskey(CommonUtils.parseDouble(info.getSortFkocskey()));
		ocs2003.setFkinp1001(CommonUtils.parseDouble(info.getInOutKey()));
		ocs2003.setInputGwa(info.getInputGwa());
		ocs2003.setNdayOccurYn("N");
		ocs2003.setPkocs1024(CommonUtils.parseDouble(info.getPkocs1024()));
		ocs2003.setBroughtDrgYn(info.getBroughtDrgYn());
		ocs2003.setInsteadYn(insteadYn);
		ocs2003.setInsteadId(insteadId);
		ocs2003.setInsteadDate(insteadDate);
		ocs2003.setInsteadTime(insteadTime);
		ocs2003.setApproveYn(info.getApproveYn());
		ocs2003.setPostapproveYn(info.getPostapproveYn());
		ocs2003.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setStartTime(info.getStartTime());
		ocs2003.setStartId(info.getStartId());
		ocs2003.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
		ocs2003.setEndTime(info.getStartTime());
		ocs2003.setEndId(info.getStartId());
		
		ocs2003Repository.save(ocs2003);
		return ocs2003;
	}
	
	private Integer updateOcs2003(String hospCode, String userId, Date sysDate, OcsiModelProto.OCS2003P01LaySaveLayoutInfo info){
		return ocs2003Repository.updateOcs2003P01(sysDate
				, userId
				, info.getOrderGubun()
				, CommonUtils.parseDouble(info.getSuryang())
				, info.getOrdDanui()
				, info.getDvTime()
				, CommonUtils.parseDouble(info.getDv())
				, info.getNdayYn()
				, CommonUtils.parseDouble(info.getNalsu())
				, info.getJusa()
				, info.getBogyongCode()
				, info.getEmergency()
				, info.getJaeryoJundalYn()
				, info.getJundalTable()
				, info.getJundalPart()
				, info.getMovePart()
				, info.getMuhyo()
				, info.getPortableYn()
				//, info.getAntiCancerYn() // TODO
				, null
				, info.getDcYn()
				, info.getDcGubun()
				, info.getBannabYn()
				, info.getBannabConfirm()
				, info.getPowderYn()
				, DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD)
				, info.getHopeTime()
				, CommonUtils.parseDouble(info.getDv1())
				, CommonUtils.parseDouble(info.getDv2())
				, CommonUtils.parseDouble(info.getDv3())
				, CommonUtils.parseDouble(info.getDv4())
				, CommonUtils.parseDouble(info.getDv5())
				, CommonUtils.parseDouble(info.getDv6())
				, CommonUtils.parseDouble(info.getDv7())
				, CommonUtils.parseDouble(info.getDv8())
				, info.getMixGroup()
				, info.getOrderRemark()
				, info.getNurseRemark()
				, info.getBomOccurYn()
				, CommonUtils.parseDouble(info.getBomSourceKey())
				, info.getNurseConfirmUser()
				, DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD)
				, info.getNurseConfirmTime()
				, info.getRegularYn()
				, info.getHubalChangeYn()
				, info.getPharmacy()
				, info.getJusaSpdGubun()
				, info.getDrgPackYn()
				, CommonUtils.parseDouble(info.getSortFkocskey())
				, info.getWonyoiOrderYn()
				, info.getSpecimenCode()
				, CommonUtils.parseDouble(info.getGroupSer())
				, info.getInputGubun()
				, info.getBroughtDrgYn()
				, DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD)
				, info.getStartTime()
				, info.getStartId()
				, DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD)
				, info.getEndTime()
				, info.getEndId()
				, CommonUtils.parseDouble(info.getPkocs1024())
				, hospCode
				, CommonUtils.parseDouble(info.getPkocskey()));
	}
}
