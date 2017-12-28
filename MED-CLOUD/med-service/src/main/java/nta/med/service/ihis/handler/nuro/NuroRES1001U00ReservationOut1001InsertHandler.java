package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out1001;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
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
public class NuroRES1001U00ReservationOut1001InsertHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReservationOut1001InsertRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES1001U00ReservationOut1001InsertHandler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReservationOut1001InsertRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result =  insertOut1001(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
    private boolean insertOut1001(NuroServiceProto.NuroRES1001U00ReservationOut1001InsertRequest request, String hospCode) {
    		Out1001 out1001 = new Out1001();
			out1001.setSysDate(new Date());
			out1001.setSysId(request.getUserId());
			out1001.setUpdDate(new Date());
			out1001.setUpdId(request.getUserId());
			out1001.setHospCode(hospCode);
			out1001.setPkout1001(StringUtils.isEmpty(request.getPkout1001()) ? null : new Double(request.getPkout1001()));
			out1001.setReserYn("Y");
			out1001.setNaewonDate(DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD));
			out1001.setBunho(request.getPatientCode());
			out1001.setGwa(request.getDepartmentCode());
			out1001.setGubun(StringUtils.isEmpty(request.getType()) ? "G1" : request.getType());
			out1001.setDoctor(request.getDoctorCode());
			out1001.setResChanggu(request.getChanggu());
			out1001.setJubsuTime(request.getExamPreTime());
			out1001.setChojae(request.getExamStatus());
			out1001.setResGubun(request.getReserType());
			out1001.setNaewonType("0");
			out1001.setJubsuNo(new BigDecimal(request.getReceptionNo()));
			out1001.setResInputGubun(request.getInputType());
			out1001.setNaewonYn("N");
			out1001.setJubsuGubun("01");
			LOG.info(out1001.toString());
			out1001Repository.save(out1001);
			return true;
    }

}
