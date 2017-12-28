package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GridDoctorInfo;
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
public class NuroRES0102U00GridDoctorHandler extends ScreenHandler<NuroServiceProto.NuroRES0102U00GridDoctorRequest, NuroServiceProto.NuroRES0102U00GridDoctorResponse>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00GridDoctorHandler.class);
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00GridDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00GridDoctorRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00GridDoctorResponse.Builder response = NuroServiceProto.NuroRES0102U00GridDoctorResponse.newBuilder();
        List<NuroRES0102U00GridDoctorInfo> listNuroRES0102U00GridDoctor = res0104Repository.getNuroRES0102U00GridDoctor(request.getHospCode(), request.getDoctor());
        if (listNuroRES0102U00GridDoctor != null && !listNuroRES0102U00GridDoctor.isEmpty()) {
            for (NuroRES0102U00GridDoctorInfo item : listNuroRES0102U00GridDoctor) {
                NuroModelProto.NuroRES0102U00GridDoctorInfo.Builder info = NuroModelProto.NuroRES0102U00GridDoctorInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getDoctor())) {
                	info.setDoctor(item.getDoctor());
                }
                if (item.getStartDate() != null) {
                	info.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getEndDate() != null) {
                	info.setEndDate(DateUtil.toString(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getSayu())) {
                	info.setSayu(item.getSayu());
                }

                response.addDoctorItem(info);
            }
        }
		return response.build();
    }
}
