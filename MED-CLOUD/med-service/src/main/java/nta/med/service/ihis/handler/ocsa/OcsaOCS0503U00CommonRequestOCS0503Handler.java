package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CommonRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CommonResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsaOCS0503U00CommonRequestOCS0503Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00CommonRequest, OcsaServiceProto.OCS0503U00CommonResponse> {
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Ocs0503Repository ocs0503Repository;
	@Override
	public OCS0503U00CommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0503U00CommonRequest request)
			throws Exception {
		OcsaServiceProto.OCS0503U00CommonResponse.Builder response=OcsaServiceProto.OCS0503U00CommonResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<String> listNaewonYn=out1001Repository.OcsaOCS0503U00GetNaewonYn(hospCode, CommonUtils.parseDouble(request.getNaewonKey()));
		if(listNaewonYn != null && !listNaewonYn.isEmpty()){
			for(String naewonYn : listNaewonYn){
				CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
				builder.setDataValue(naewonYn);
				response.addNaewonYn(builder);
			}
		}
		String checkReserYn=ocs0503Repository.checkCanReserOCS0503U00(hospCode, DateUtil.toDate(request.getReserDate(),DateUtil.PATTERN_YYMMDD), request.getReserTime(), request.getReserDoctor());
		if(!StringUtils.isEmpty(checkReserYn)){
			response.setReserYn(checkReserYn);
		}
		Double ocs0503Seq=ocs0503Repository.getSeqOcs0503();
		if(ocs0503Seq !=null){
			response.setSeq(String.format("%.0f", ocs0503Seq));
		}
		return response.build();
	}
}
