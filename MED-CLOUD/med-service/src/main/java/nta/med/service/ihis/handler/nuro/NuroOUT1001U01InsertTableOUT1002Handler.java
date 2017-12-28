package nta.med.service.ihis.handler.nuro;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.out.Out1002;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroOUT1001U01InsertTableOUT1002Handler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Request, NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Response>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01InsertTableOUT1002Handler.class);
	
	@Resource
	private Out1002Repository out1002Repository;
	
	@Override
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Request request) throws Exception {
		NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Response.Builder response = NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Response.newBuilder();
		Integer result = insertTableOUT1002(request, getHospitalCode(vertx, sessionId));
		response.setResultInsert(result != null && result > 0);
		return response.build();
	}
	
	private Integer insertTableOUT1002(NuroServiceProto.NuroOUT1001U01InsertTableOUT1002Request request, String hospCode) throws Exception{
			Out1002 out1002 = new Out1002(); 
			out1002.setSysDate(new Date());
			out1002.setSysId(request.getUserId());
			out1002.setUpdDate(new Date());
			out1002.setUpdId(request.getUpdateId());
			out1002.setHospCode(hospCode);
			out1002.setFkout1001(request.getNewPkout1001());
			out1002.setGongbiCode(request.getGongbiCode1());
			out1002.setBunho(request.getBunho());
			if(!StringUtils.isEmpty(request.getPriority1())) {
				out1002.setPriority(CommonUtils.parseDouble(request.getPriority1()));
			}
			out1002Repository.save(out1002);
			return 1;
	}

}
