package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003P01SettingVisibleByUserHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01SettingVisibleByUserRequest, OcsoServiceProto.OCS1003P01SettingVisibleByUserResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(OCS1003P01SettingVisibleByUserHandler.class);                                        
	@Resource                                                                                                       
	private Out1001Repository  out1001Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003P01SettingVisibleByUserResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01SettingVisibleByUserRequest request) throws Exception {
		OcsoServiceProto.OCS1003P01SettingVisibleByUserResponse.Builder response = OcsoServiceProto.OCS1003P01SettingVisibleByUserResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		CommonModelProto.NaewonYNInfo1 naewon = request.getNaewonParam();
		if(naewon != null){
			String naewonValue = out1001Repository.getOcsLibNaewonYNInfo1(hospCode, naewon.getBunho(), 
					DateUtil.toDate(naewon.getNaewonDate(), DateUtil.PATTERN_YYMMDD),CommonUtils.parseDouble(naewon.getPkout1001()));
			if(!StringUtils.isEmpty(naewonValue)){
				response.setYnValue(naewonValue);
			}
		}
		
		CommonModelProto.NotApproveOrderCntInfo  countParam = request.getCountParam();
		if(countParam != null){
			String countValue = out1001Repository.callFnOcsGetNotapproveOrdercnt(hospCode, countParam.getIoGubun(), countParam.getInsteadYn(),
					countParam.getApproveYn(), countParam.getUserId(), countParam.getKey());
			if(StringUtils.isEmpty(countValue)){
				response.setCountValue("0");
			}else{
				response.setCountValue(countValue);
			}
		}
		return response.build();
	}                                                                                                                 
}