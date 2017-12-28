package nta.med.service.ihis.handler.ocsi;

import java.math.BigInteger;
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
import nta.med.core.domain.ocs.Ocs6013;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.dao.medi.ocs.Ocs2006Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.dao.medi.ocs.Ocs6013Repository;
import nta.med.data.dao.medi.ocs.Ocs6015Repository;
import nta.med.data.dao.medi.ocs.Ocs6016Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10SaveLayoutHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS6010U10SaveLayoutHandler.class);
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Resource
	private Ocs6013Repository ocs6013Repository;
	
	@Resource
	private Adm0003Repository adm0003Repository;
	
	@Resource
	private Ocs6015Repository ocs6015Repository;
	
	@Resource
	private Ocs6016Repository ocs6016Repository;
	
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Resource
	private Ocs2006Repository ocs2006Repository;

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(rollbackFor = Exception.class)
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = request.getUserId();
		
		List<OcsiModelProto.OCS6010U10SaveLayoutInfo> saveList = request.getSaveListList();

		if (CollectionUtils.isEmpty(saveList)) {
			response.setResult(false);
			return response.build();
		}
		
		for (OcsiModelProto.OCS6010U10SaveLayoutInfo info : saveList) {
			
			switch (info.getTableId()) {
			case "OCS2003":
				response = handleOcs2003(hospCode, language, userId, info);
				break;
			case "OCS6013":
				response = handleOcs6013(hospCode, language, userId, info);
				break;
			case "OCS6015":
				response = handleOcs6015(hospCode, language, userId, info);
				break;
			case "OCS2005":
				response = handleOcs2005(hospCode, language, userId, info);
				break;
			default:
				break;
			}
			
			if(!response.getResult()){
				throw new ExecutionException(response.build());
			}
		}
		
		return response.build();
	}

	private UpdateResponse.Builder handleOcs2003(String hospCode, String language, String userId, OcsiModelProto.OCS6010U10SaveLayoutInfo info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		if(!"Y".equals(info.getDelFlag())){
			if(!StringUtils.isEmpty(info.getNurseActUser())){
				ocs2003Repository.updateOcs2003InOCS6010U10SaveLayoutCase01(hospCode
						, CommonUtils.parseDouble(info.getPk())
						, userId
						, info.getNurseActUser()
						, DateUtil.toDate(info.getNurseActDate(), DateUtil.PATTERN_YYMMDD));
			} else if(!StringUtils.isEmpty(info.getNurseActDate())){
				ocs2003Repository.updateOcs2003InOCS6010U10SaveLayoutCase02(hospCode
						, CommonUtils.parseDouble(info.getPk())
						, userId);
			} else if("Y".equals(info.getConfirmYn())){
				ocs2003Repository.updateOcs2003InOCS6010U10SaveLayoutCase03(hospCode
						, CommonUtils.parseDouble(info.getPk())
						, userId
						, info.getPickupUser());
			} else {
				ocs2003Repository.updateOcs2003InOCS6010U10SaveLayoutCase04(hospCode
						, CommonUtils.parseDouble(info.getPk())
						, userId);
			}
		}
		else if("Y".equals(info.getDelFlag())){
			ocs6010Repository.callPrOcsPrnCancelProc(hospCode, CommonUtils.parseDouble(info.getPk()));
		}
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder handleOcs6013(String hospCode, String language, String userId, OcsiModelProto.OCS6010U10SaveLayoutInfo info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		if(!"Y".equals(info.getDelFlag())){
			if(info.getOrderDate().equals(info.getOriginOrderDate()) && info.getInputGubun().equals(info.getOriginInputGubun())){
				response.setResult(true);
				return response;
			}
			
			double tJaewonil = 0.0;
			double tGroupSer = 0.0;
			
			CommonProcResultInfo spInfo = ocs6010Repository.callPrOcsCreatePlanJaewonil(hospCode
					, CommonUtils.parseDouble(info.getFkocs6010())
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
					, userId);
			if(spInfo == null || StringUtils.isEmpty(spInfo.getStrResult1())){
				LOGGER.info(String.format("Call PR_OCS_CREATE_PLAN_JAEWONIL fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
			
			if(!"0".equals(spInfo.getStrResult2())){
				LOGGER.info(String.format("Call PR_OCS_CREATE_PLAN_JAEWONIL fail, hosp_code = %s, IO_FLAG = %s", hospCode, spInfo.getStrResult2()));
				response.setResult(false);
				return response;
			}
			
			tJaewonil = CommonUtils.parseDouble(spInfo.getStrResult1());
			
			if(!StringUtils.isEmpty(info.getOrderDate()) || !StringUtils.isEmpty(info.getInputGubun())){
				tGroupSer = ocs6013Repository.getNextGroupSerOcs6013(hospCode
						, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getFkocs6010()));
			}
			
			ocs6013Repository.updateOcs6013InOcs6010U01(hospCode
					, CommonUtils.parseDouble(info.getPk())
					, userId
					, tJaewonil
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
					, info.getInputGubun()
					, tGroupSer);
		} 
		else if("Y".equals(info.getDelFlag())){
			List<Ocs6013> lstOcs6013 = ocs6013Repository.findByHospCodePkocs6013(hospCode, CommonUtils.parseDouble(info.getPk()));
			if(CollectionUtils.isEmpty(lstOcs6013)){
				LOGGER.info(String.format("Could not find OCS6013: hosp_code = %s, pk = %s", hospCode, info.getPk()));
				response.setResult(false);
				return response;
			}
			
			if(lstOcs6013.get(0).getRefFkocs2003() != null){
				String msg = adm0003Repository.getFormEnvironInfoMessage(language, new Double(2057));
				LOGGER.info(String.format("Handle Ocs6013 fail, msg_code = 2057, msg = , hosp_code = %s", msg, hospCode));
				response.setResult(false);
				response.setMsg(msg == null ? "" : msg);
				return response;
			}
			
			ocs6013Repository.deleteByHospCodePkocs6013(hospCode, CommonUtils.parseDouble(info.getPk()));
		}
		
		response.setResult(true);
		return response;
	}

	private UpdateResponse.Builder handleOcs6015(String hospCode, String language, String userId, OcsiModelProto.OCS6010U10SaveLayoutInfo info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		if(!"Y".equals(info.getDelFlag())){
			if(info.getOrderDate().equals(info.getOriginOrderDate()) && info.getInputGubun().equals(info.getOriginInputGubun())){
				response.setResult(true);
				return response;
			}
			
			double tJaewonil = 0.0;
			
			CommonProcResultInfo spInfo = ocs6010Repository.callPrOcsCreatePlanJaewonil(hospCode
					, CommonUtils.parseDouble(info.getFkocs6010())
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
					, userId);
			if(spInfo == null || StringUtils.isEmpty(spInfo.getStrResult1())){
				LOGGER.info(String.format("Call PR_OCS_CREATE_PLAN_JAEWONIL fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
			
			if(!"0".equals(spInfo.getStrResult2())){
				LOGGER.info(String.format("Call PR_OCS_CREATE_PLAN_JAEWONIL fail, hosp_code = %s, IO_FLAG = %s", hospCode, spInfo.getStrResult2()));
				response.setResult(false);
				return response;
			}
			
			tJaewonil = CommonUtils.parseDouble(spInfo.getStrResult1());
			
			// check duplicate
			String strCheck = ocs6015Repository.checkDupOcs6015InOcs6010U10(hospCode
					, CommonUtils.parseDouble(info.getFkocs6010())
					, tJaewonil
					, info.getInputGubun()
					, info.getOrderGubun()
					, info.getHangmogCode());
			
			if("Y".equals(strCheck)){
				LOGGER.info(String.format("Handle Ocs6015, check duplicate is not pass: hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
			
			Double tPkSeq = ocs6015Repository.getNextSeqOcs6015(hospCode, CommonUtils.parseDouble(info.getFkocs6010()), tJaewonil, info.getInputGubun());
			
			ocs6015Repository.updateOcs6015InOCS6010U10Case01(userId
					, tJaewonil
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
					, info.getInputGubun()
					, tPkSeq
					, hospCode
					, CommonUtils.parseDouble(info.getFkocs6010())
					, info.getOriginInputGubun()
					, DateUtil.toDate(info.getOriginOrderDate(), DateUtil.PATTERN_YYMMDD)
					, CommonUtils.parseDouble(info.getPk()));
		}
		else if("Y".equals(info.getDelFlag())){
			String strCheck = ocs6015Repository.checkPlanFromDateInOcs6010U10(hospCode
					, CommonUtils.parseDouble(info.getFkocs6010())
					, CommonUtils.parseDouble(info.getJaewonil())
					, info.getInputGubun()
					, CommonUtils.parseDouble(info.getPk())
					, info.getOrderDate());
			
			if(StringUtils.isEmpty(strCheck)){
				LOGGER.info(String.format("checkPlanFromDateInOcs6010U10 is not pass, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
			
			if(!"Y".equals(strCheck)){
				ocs6015Repository.updateOcs6015InOcs6010U10Case02(hospCode
						, CommonUtils.parseDouble(info.getFkocs6010())
						, CommonUtils.parseDouble(info.getJaewonil())
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getPk())
						, info.getOrderDate());
			} else {
				int rowDeleted = ocs6015Repository.deleteOcs6015InOCS6010U10(hospCode
						, CommonUtils.parseDouble(info.getFkocs6010())
						, CommonUtils.parseDouble(info.getJaewonil())
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getPk()));
				
				if(rowDeleted > 0){
					ocs6016Repository.deleteOcs6016InOCS6010U10(hospCode
							, CommonUtils.parseDouble(info.getFkocs6010())
							, CommonUtils.parseDouble(info.getJaewonil())
							, info.getInputGubun()
							, CommonUtils.parseDouble(info.getPk()));
				}
			}
		}
		
		response.setResult(true);
		return response;
	}

	private UpdateResponse.Builder handleOcs2005(String hospCode, String language, String userId, OcsiModelProto.OCS6010U10SaveLayoutInfo info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		if("Y".equals(info.getDelFlag())){
			BigInteger cnt = ocs2015Repository.countOcs2015InOCS6010U10(hospCode
					, info.getBunho()
					, CommonUtils.parseDouble(info.getFkinp1001())
					, DateUtil.toDate(info.getSourceOrderDate(), DateUtil.PATTERN_YYMMDD)
					, info.getInputGubun()
					, CommonUtils.parseDouble(info.getPk()));
			
			if(!"0".equals(String.valueOf(cnt))){
				String msg = adm0003Repository.getFormEnvironInfoMessage(language, new Double(3259));
				LOGGER.info(String.format("Handle Ocs2005 fail, msg_code = 3259, msg = , hosp_code = %s", msg, hospCode));
				response.setResult(false);
				response.setMsg(msg == null ? "" : msg);
				return response;
			}
			
			int rowDeleted = ocs2006Repository.deleteOcs2006InOCS6010U10SaveLayout(hospCode
					, info.getBunho()
					, CommonUtils.parseDouble(info.getFkinp1001())
					, info.getInputGubun()
					, CommonUtils.parseDouble(info.getPk()));
			
			if(rowDeleted > 0){
				ocs2005Repository.deleteOcs2005InOCS6010U10SaveLayout(hospCode
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001())
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getPk()));
			}
		}
		else {
			if("Y".equals(info.getConfirmYn())){
				ocs2005Repository.updateOcs2005InOCS6010U10SaveLayoutCase01(hospCode,
						CommonUtils.parseDouble(info.getPkocs2005()), userId, info.getPickupUser());
			}
			else {
				ocs2005Repository.updateOcs2005InOCS6010U10SaveLayoutCase02(hospCode,
						CommonUtils.parseDouble(info.getPkocs2005()), userId);
			}
		}
		
		response.setResult(true);
		return response;
	}
}
