package nta.med.service.ihis.handler.nuri;

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
import nta.med.core.domain.nur.Nur1023;
import nta.med.core.domain.nur.Nur1122;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.dao.medi.nur.Nur1023Repository;
import nta.med.data.dao.medi.nur.Nur1122Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1020U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR1020U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR1020U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(NUR1020U00SaveLayoutHandler.class);
	
	@Resource
	private Nur1020Repository nur1020Repository;
	
	@Resource
	private Nur1023Repository nur1023Repository;
	
	@Resource
	private Nur1122Repository nur1122Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1020U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NuriModelProto.NUR1020U00GrdDataInfo> grdData = request.getGrdDataList();
		List<NuriModelProto.NUR1020U00GrdNur1023Info> grd1023 = request.getGrd1023List();
		List<NuriModelProto.NUR1020U00grdNUR1122Info> grd1122 = request.getGrd1122List();
		List<NuriModelProto.NUR1020U00GrdDeleteInfo > grdDelete = request.getGrdDeleteList(); 
		
		// handle grd_delete
		handleGrdDelete(hospCode, grdDelete);
		
		// handle grd_data
		response = handleGrdData(hospCode, userId, grdData);
		if(!response.getResult()){
			LOGGER.info(String.format("Handle Grd Data fail, hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		// handle grd_1023
		handleGrd1023(hospCode, userId, grd1023);
		
		// handle grd_1122
		handleGrd1122(hospCode, userId, grd1122);
		
		response.setResult(true);
		return response.build();
	}
	
	private boolean handleGrdDelete(String hospCode, List<NuriModelProto.NUR1020U00GrdDeleteInfo > grdDelete){
		for (NuriModelProto.NUR1020U00GrdDeleteInfo info : grdDelete) {
			nur1020Repository.deleteByHospCodeBunhoFkinp1001YmdTimeGubun(hospCode
					, info.getBunho()
					, CommonUtils.parseDouble(info.getFkinp1001())
					, DateUtil.toDate(info.getYmd(), DateUtil.PATTERN_YYMMDD)
					, info.getTime());
		}
		
		return true;
	}
	
	private UpdateResponse.Builder handleGrdData(String hospCode, String userId, List<NuriModelProto.NUR1020U00GrdDataInfo> grdData){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		for (NuriModelProto.NUR1020U00GrdDataInfo info : grdData) {
			// execute PR_NUR_INPUT_VITAL_VALUE
			nur1020Repository.callPrNurInputVitalValue(userId
					, hospCode
					, info.getBunho()
					, CommonUtils.parseDouble(info.getFkinp1001())
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
					, info.getGubun1()
					, info.getGubun2()
					, info.getGubun3()
					, (StringUtils.isEmpty(info.getValue()) ? null : info.getValue()));
			
			if("C".equals(info.getGubun1()) 
					&& "O".equals(info.getGubun2()) 
					&& "UT".equals(info.getGubun3()) 
					&& !"0".equals(info.getValue()) 
					&& !StringUtils.isEmpty(info.getValue())){
				
				// execute PR_CPL_INSERT_URINE
				CommonProcResultInfo pResult = nur1020Repository.callPrCplInsertUrine(hospCode
						, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001()));
				
				if(!"0".equals(pResult.getStrResult1())){
					LOGGER.info(String.format("Execute procedure PR_CPL_INSERT_URINE fail - hosp_code = %s", hospCode));
					response.setResult(false);
					response.setMsg(pResult.getStrResult2() == null ? "" : pResult.getStrResult2());
					return response;
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private boolean handleGrd1023(String hospCode, String userId, List<NuriModelProto.NUR1020U00GrdNur1023Info> grd1023){
		Date sysDate = new Date();
		for (NuriModelProto.NUR1020U00GrdNur1023Info info : grd1023) {
			List<Nur1023> dts = nur1023Repository.findByHospCodeFkinp1001BunhoOrderdate(hospCode
					, CommonUtils.parseDouble(info.getFkinp1001())
					, info.getBunho()
					, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
			
			if(!CollectionUtils.isEmpty(dts)){
				// update
				for (Nur1023 nur1023 : dts) {
					nur1023.setUpdId(userId);
					nur1023.setUpdDate(sysDate);
					nur1023.setVspatnGubun(info.getVspatnGubun());
					nur1023Repository.save(nur1023);
				}
			} else {
				// insert
				Nur1023 nur1023 = new Nur1023();
				nur1023.setSysDate(sysDate);
				nur1023.setSysId(userId);
				nur1023.setUpdDate(sysDate);
				nur1023.setUpdId(userId);
				nur1023.setHospCode(hospCode);
				nur1023.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur1023.setBunho(info.getBunho());
				nur1023.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
				nur1023.setVspatnGubun(info.getVspatnGubun());
				
				nur1023Repository.save(nur1023);
			}
		}
		
		return true;
	}

	private boolean handleGrd1122(String hospCode, String userId, List<NuriModelProto.NUR1020U00grdNUR1122Info> grd1122){
		Date sysDate = new Date();
		
		for (NuriModelProto.NUR1020U00grdNUR1122Info info : grd1122) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState()) || DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				// check if exists
				List<Nur1122> listNur1122 = nur1122Repository.findByHospCodeFkinp1001YmdHangmogName(hospCode
						, CommonUtils.parseDouble(info.getFkinp1001())
						, DateUtil.toDate(info.getYmd(), DateUtil.PATTERN_YYMMDD)
						, info.getHangmogName());
				
				if(!CollectionUtils.isEmpty(listNur1122)){
					// update
					Nur1122 nur1122 = listNur1122.get(0);
					nur1122.setUpdDate(sysDate);
					nur1122.setUpdId(userId);
					nur1122.setHangmogValue1(info.getHangmogValue1());
					nur1122.setHangmogValue2(info.getHangmogValue2());
					nur1122.setHangmogValue3(info.getHangmogValue3());
					
					nur1122Repository.save(nur1122);
				} else {
					// insert
					Nur1122 nur1122 = new Nur1122();
					nur1122.setSysDate(sysDate);
					nur1122.setSysId(userId);
					nur1122.setUpdDate(sysDate);
					nur1122.setUpdId(userId);
					nur1122.setBunho(info.getBunho());
					nur1122.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
					nur1122.setYmd(DateUtil.toDate(info.getYmd(), DateUtil.PATTERN_YYMMDD));
					nur1122.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? "999" : info.getHangmogCode());
					nur1122.setHangmogValue1(info.getHangmogValue1());
					nur1122.setHangmogValue2(info.getHangmogValue2());
					nur1122.setHangmogValue3(info.getHangmogValue3());
					nur1122.setHospCode(hospCode);
					nur1122.setHangmogName(info.getHangmogName());
					
					nur1122Repository.save(nur1122);
				}
			} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur1122Repository.deleteByHospCodeFkinp1001YmdHangmogName(hospCode
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001())
						, DateUtil.toDate(info.getYmd(), DateUtil.PATTERN_YYMMDD)
						, info.getHangmogName());
			} else if(DataRowState.UNCHANGED.getValue().equals(info.getDataRowState())){
				if(StringUtils.isEmpty(info.getHangmogValue1())
						&& StringUtils.isEmpty(info.getHangmogValue2())
						&& StringUtils.isEmpty(info.getHangmogValue3())){
					
					nur1122Repository.deleteByHospCodeFkinp1001YmdHangmogCode(hospCode
							, info.getBunho()
							, CommonUtils.parseDouble(info.getFkinp1001())
							, DateUtil.toDate(info.getYmd(), DateUtil.PATTERN_YYMMDD)
							, info.getHangmogCode());
				}
			}
		}
		
		return true;
	}
}
