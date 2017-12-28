package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
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
public class NuroOUT1001U01LoadDoctorJinryoTimeHandler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeRequest, NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01LoadDoctorJinryoTimeHandler.class);
	@Resource
	private Out0103Repository out0103Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Route(global = false)
	@Transactional
	public NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeRequest request) throws Exception {
		List<String> nuroOUT1001U01LoadDoctorJinryo  =  out0103Repository.callPrcLoadDoctorJinryoTime(getHospitalCode(vertx, sessionId), request.getGwa(),request.getDoctor(),
        		request.getNaewonDate(),request.getJubsuTime(), "", "", "","" );
		NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeResponse.Builder response = NuroServiceProto.NuroOUT1001U01LoadDoctorJinryoTimeResponse.newBuilder();
		if(nuroOUT1001U01LoadDoctorJinryo!= null){
			response.setFromTime(nuroOUT1001U01LoadDoctorJinryo.get(0) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(0));
			response.setToTime(nuroOUT1001U01LoadDoctorJinryo.get(1) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(1));
			response.setSchFlag(nuroOUT1001U01LoadDoctorJinryo.get(2) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(2));
		}
		return response.build();
	}
}
