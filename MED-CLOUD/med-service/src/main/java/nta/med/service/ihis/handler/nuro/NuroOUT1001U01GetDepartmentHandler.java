package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetDepartmentInfo;
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
public class NuroOUT1001U01GetDepartmentHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetDepartmentRequest, NuroServiceProto.NuroOUT1001U01GetDepartmentResponse>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01GetDepartmentHandler.class);
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetDepartmentResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetDepartmentRequest request) throws Exception {
		List<NuroOUT1001U01GetDepartmentInfo> listNuroOUT1001U01GetDepartmentInfo = bas0260Repository.getNuroOUT1001U01GetDepartmentInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), 
				request.getBuseoYmd(), request.getBuseoGubun(), request.getFind1());
        NuroServiceProto.NuroOUT1001U01GetDepartmentResponse.Builder response= NuroServiceProto.NuroOUT1001U01GetDepartmentResponse.newBuilder();
        if (listNuroOUT1001U01GetDepartmentInfo != null && !listNuroOUT1001U01GetDepartmentInfo.isEmpty()) {
            for (NuroOUT1001U01GetDepartmentInfo item : listNuroOUT1001U01GetDepartmentInfo) {
                NuroModelProto.NuroOUT1001U01GetDepartmentInfo.Builder builder = NuroModelProto.NuroOUT1001U01GetDepartmentInfo.newBuilder();
                if(!StringUtils.isEmpty(item.getGwaName())) {
                	builder.setGwaName(item.getGwaName());
            	}
                if(!StringUtils.isEmpty(item.getGwa())) {
                	builder.setGwa(item.getGwa());
            	}
                if(!StringUtils.isEmpty(item.getBuseoCode())) {
                	builder.setBuseoCode(item.getBuseoCode());
            	}
                response.addDeptItem(builder);
            }
        }
		return response.build();
	}
}
