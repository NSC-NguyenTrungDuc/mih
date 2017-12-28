package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadCheckChojaeJpnInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroOUT1001U01LoadCheckChojaeJpnHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnRequest, NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01LoadCheckChojaeJpnHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Route(global = false)
	@Transactional
	public NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnRequest request) throws Exception {
		NuroOUT1001U01LoadCheckChojaeJpnInfo info= out1001Repository.getNuroOUT1001U01LoadCheckChojaeJpnInfo(getHospitalCode(vertx, sessionId), request.getNaewonDate(), 
				request.getBunho(), request.getGubun(), request.getGwa(), CommonUtils.parseDouble(request.getJubsuNo()), "", "", "", "");
		NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnResponse.Builder response = NuroServiceProto.NuroOUT1001U01LoadCheckChojaeJpnResponse.newBuilder();
		if(info != null){			
			NuroModelProto.NuroOUT1001U01LoadCheckChojaeJpnInfo.Builder buidler =  NuroModelProto.NuroOUT1001U01LoadCheckChojaeJpnInfo.newBuilder();
			if (!StringUtils.isEmpty(info.getChojae())) {
				buidler.setChojae(info.getChojae());
			}
			if (!StringUtils.isEmpty(info.getChtChojae())) {
				buidler.setChtChojae(info.getChtChojae());
			}
			if (!StringUtils.isEmpty(info.getGajubsuGubun())) {
				buidler.setGajubsuGubun(info.getGajubsuGubun());
			}
			if (!StringUtils.isEmpty(info.getErr())) {
				buidler.setErr(info.getErr());
			}
			response.setChojaeJpnItem(buidler);
		}
		return response.build();
	}

}
