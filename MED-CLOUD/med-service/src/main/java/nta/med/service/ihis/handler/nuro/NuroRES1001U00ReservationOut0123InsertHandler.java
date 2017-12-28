package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out0123;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroRES1001U00ReservationOut0123InsertHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut0123InsertRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut0123InsertHandler.class);
	@Resource
	private Out0123Repository out0123Repository;

    @Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut0123InsertRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
        response.setResult(insertOut0123(request, hospCode));
		return response.build();
	}
    
    private boolean insertOut0123(NuroServiceProto.NuroRES1001U00ReservationOut0123InsertRequest request, String hospCode) {
			Out0123 out0123 = new Out0123();
			out0123.setSysDate(new Date());
			out0123.setSysId(request.getUserId());
			out0123.setUpdDate(new Date());
			out0123.setUpdId(request.getUserId());
			out0123.setHospCode(hospCode);
			out0123.setBunho(request.getPatientCode());
			out0123.setSeq(new Double(1));
			out0123.setReqDate(new Date());
			out0123.setReqTime(DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM));
			out0123.setReqGwa(request.getDepartmentCode());
			out0123.setReqDoctor(request.getDoctorCode());
			out0123.setAnswerDate(DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD));
			out0123.setAnswerTime(request.getExamPreTime());
			out0123.setAnswerGwa("%");
			out0123.setAnswerDoctor("%");
			out0123.setAnswerEndYn("Y");
			out0123.setInOutGubun("O");
			out0123.setComments(request.getReserComment());
			out0123.setFkout1001(CommonUtils.parseDouble(request.getPkout1001()));
			out0123.setCommentType("1");
			out0123.setReserGubun(request.getReserType());
			LOG.info(out0123.toString());
			out0123Repository.save(out0123);
			return true;
    }

}
