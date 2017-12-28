package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.out.Out1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;

@Transactional
@Service
@Scope("prototype")
public class NuroOUT1001U01UpdateTableOUT1001Handler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Request, NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Response>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01UpdateTableOUT1001Handler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Request request) throws Exception {
		NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Response.Builder response = NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Response.newBuilder();
		boolean result = updateTableOUT1001(request, getHospitalCode(vertx, sessionId));
        response.setValueUpdateOut1001(result);
        return response.build();
	}
	
	private boolean updateTableOUT1001(NuroServiceProto.NuroOUT1001U01UpdateTableOUT1001Request request, String hospCode) throws Exception{
			BigDecimal jubsuNo = new BigDecimal(request.getJubsuNo());
			Double pkout1001 = new Double(request.getPkout1001());
			Out1001 out = out1001Repository.findByHospCodeAndPkOut1001(hospCode, pkout1001);
			
			if( out1001Repository.updateTableOUT1001(request.getUserId(), new Date(), request.getDoctor(), request.getChojae(), jubsuNo,
					request.getGubun(), request.getJubsuTime(), request.getArriveTime(), request.getJubsuGubun(),
					 request.getCheckNaewon(), out.getReceptRefId(), hospCode, pkout1001) > 0){
				return true;
			}else{
				return false;
			}
	}
	
}
