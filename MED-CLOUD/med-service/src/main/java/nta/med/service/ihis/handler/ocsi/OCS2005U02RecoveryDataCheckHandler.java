package nta.med.service.ihis.handler.ocsi;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckInfo;
import nta.med.data.model.ihis.ocsi.RecoveryMaxMinInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02RecoveryDataCheckRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02RecoveryDataCheckResponse;

@Service
@Scope("prototype")
public class OCS2005U02RecoveryDataCheckHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02RecoveryDataCheckRequest, OcsiServiceProto.OCS2005U02RecoveryDataCheckResponse> {

	@Resource
	private Inp5001Repository inp5001Repository;
	
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	public OCS2005U02RecoveryDataCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02RecoveryDataCheckRequest request) throws Exception {
		
		OcsiServiceProto.OCS2005U02RecoveryDataCheckResponse.Builder response = OcsiServiceProto.OCS2005U02RecoveryDataCheckResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		OcsiModelProto.OCS2005U02grdOCS2005Info reqInfo = request.getGrdocs2005();
		List<OCS2005U02RecoveryDataCheckInfo> infos = inp5001Repository.getOCS2005U02RecoveryDataCheckInfo(hospCode, DateUtil.toDate(reqInfo.getDrtFromDate(), DateUtil.PATTERN_YYMMDD));
		if(!CollectionUtils.isEmpty(infos)){
			response.setFinalB(infos.get(0).getNutJoMagamYn());
			response.setFinalL(infos.get(0).getNutJuMagamYn());
			response.setFinalD(infos.get(0).getNutSeokMagamYn());
		} else {
			response.setFinalB("");
			response.setFinalL("");
			response.setFinalD("");
		}
		
		Date fromDate = null;
		Date toDate = null;
		
		if(DataRowState.MODIFIED.getValue().equals(reqInfo.getDataRowState())){
			List<RecoveryMaxMinInfo> maxMinInfoList = ocs2015Repository.getRecoveryMaxMinInfo(hospCode, CommonUtils.parseDouble(reqInfo.getPkocs2005()),
					DateUtil.toDate(reqInfo.getDrtFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(reqInfo.getDrtToDate(), DateUtil.PATTERN_YYMMDD));
			if(CollectionUtils.isEmpty(maxMinInfoList)){
				return response.build();
			}
			
			RecoveryMaxMinInfo maxMinDateInfo = maxMinInfoList.get(0);
			
			fromDate = maxMinDateInfo.getMinNutDate() == null ? DateUtil.toDate(reqInfo.getDrtFromDate(), DateUtil.PATTERN_YYMMDD) : maxMinDateInfo.getMinNutDate();
			if(maxMinDateInfo.getMinNutDate() != null){
				toDate = maxMinDateInfo.getMaxNutDate() == null ? DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD) : maxMinDateInfo.getMaxNutDate();
			} 
			else {
				toDate = StringUtils.isEmpty(reqInfo.getDrtToDate()) ? DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD) : DateUtil.toDate(reqInfo.getDrtToDate(), DateUtil.PATTERN_YYMMDD);
			}
		}
		else{
			fromDate = DateUtil.toDate(reqInfo.getDrtFromDate(), DateUtil.PATTERN_YYMMDD);
			toDate = StringUtils.isEmpty(reqInfo.getDrtToDate()) ? DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD) : DateUtil.toDate(reqInfo.getDrtToDate(), DateUtil.PATTERN_YYMMDD);
		}
		
		List<OCS2005U02RecoveryDataCheckInfo> lstInfo = inp5001Repository.getOCS2005U02RecoveryDataCheckInfoByMinMaxDate(hospCode, fromDate, toDate);
		if(!CollectionUtils.isEmpty(lstInfo)){
			for (OCS2005U02RecoveryDataCheckInfo info : lstInfo) {
				OcsiModelProto.OCS2005U02RecoveryDataCheckInfo.Builder pInfo = OcsiModelProto.OCS2005U02RecoveryDataCheckInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addDtItem(pInfo);
			}
		}
		
		return response.build();
	}

}
