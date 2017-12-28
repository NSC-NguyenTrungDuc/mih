package nta.med.service.ihis.handler.system;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.system.FnInpLoadJaewonIlsuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FnInpLoadJaewonIlsuRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FnInpLoadJaewonIlsuResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class FnInpLoadJaewonIlsuHandler 
	extends ScreenHandler<SystemServiceProto.FnInpLoadJaewonIlsuRequest, SystemServiceProto.FnInpLoadJaewonIlsuResponse> {
	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public FnInpLoadJaewonIlsuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, FnInpLoadJaewonIlsuRequest request)
			throws Exception {
		SystemServiceProto.FnInpLoadJaewonIlsuResponse.Builder response = SystemServiceProto.FnInpLoadJaewonIlsuResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double naewonKey = CommonUtils.parseDouble(request.getNaewonKey());				
		List<FnInpLoadJaewonIlsuInfo> listInfo = ocs6010Repository.getFnInpLoadJaewonIlsuInfo(hospCode, request.getBunho(), naewonKey);
		if(listInfo != null && listInfo.size() > 0 ){
			for(FnInpLoadJaewonIlsuInfo info : listInfo){
				SystemModelProto.FnInpLoadJaewonIlsuInfo.Builder builder = SystemModelProto.FnInpLoadJaewonIlsuInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				
				response.addLsuItem(builder);
			}
		}
		Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Integer retVal = inp1001Repository.getFnInpLoadJaewonIlsu(hospCode, naewonKey, orderDate);
		if(retVal != null){
			response.setRetVal(retVal.toString());
		}
		return response.build();
	}
}
