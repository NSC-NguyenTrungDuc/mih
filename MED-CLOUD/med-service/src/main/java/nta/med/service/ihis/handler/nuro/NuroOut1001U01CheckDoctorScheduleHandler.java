package nta.med.service.ihis.handler.nuro;

import nta.med.core.common.annotation.Route;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0103Repository;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class NuroOut1001U01CheckDoctorScheduleHandler extends ScreenHandler<NuroServiceProto.NuroOut1001U01CheckDoctorScheduleRequest, NuroServiceProto.NuroOut1001U01CheckDoctorScheduleResponse> {
	private static final Log LOG = LogFactory.getLog(NuroOut1001U01CheckDoctorScheduleHandler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Resource
	private Out0103Repository out0103Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOut1001U01CheckDoctorScheduleRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Route(global = false)
	@Transactional
	public NuroServiceProto.NuroOut1001U01CheckDoctorScheduleResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOut1001U01CheckDoctorScheduleRequest request) throws Exception {
		NuroServiceProto.NuroOut1001U01CheckDoctorScheduleResponse.Builder response = NuroServiceProto.NuroOut1001U01CheckDoctorScheduleResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<String> listObject = res0102Repository.getDoctorExamStatus(hospCode, hospCode, request.getType(), DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD), request.getJubsuTime(), request.getDoctor(), false);
    	if (listObject != null && !listObject.isEmpty()) {
    		response.setRet(listObject.get(0));
    		if(!"0".equalsIgnoreCase(listObject.get(0))){
    			List<String> nuroOUT1001U01LoadDoctorJinryo  =  out0103Repository.callPrcLoadDoctorJinryoTime(hospCode, request.getGwa(),request.getDoctor(),
	            		request.getNaewonDate(),request.getJubsuTime(), "", "", "","" );

				if(nuroOUT1001U01LoadDoctorJinryo!= null){
					response.setFromTime(nuroOUT1001U01LoadDoctorJinryo.get(0) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(0));
					response.setToTime(nuroOUT1001U01LoadDoctorJinryo.get(1) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(1));
					response.setSchFlag(nuroOUT1001U01LoadDoctorJinryo.get(2) == null ? "" : nuroOUT1001U01LoadDoctorJinryo.get(2));
				}
    		}
        }
		return response.build();
	}
}
