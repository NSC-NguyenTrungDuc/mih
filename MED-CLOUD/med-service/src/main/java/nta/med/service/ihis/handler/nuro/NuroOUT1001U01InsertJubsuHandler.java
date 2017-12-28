package nta.med.service.ihis.handler.nuro;

import java.math.BigDecimal;
import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.out.Out1001;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.out.Out1001Repository;
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
public class NuroOUT1001U01InsertJubsuHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01InsertJubsuRequest, NuroServiceProto.NuroOUT1001U01InsertJubsuResponse>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01InsertJubsuHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private CommonRepository commonRepository;

	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01InsertJubsuRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01InsertJubsuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01InsertJubsuRequest request) throws Exception {
		NuroServiceProto.NuroOUT1001U01InsertJubsuResponse.Builder response = NuroServiceProto.NuroOUT1001U01InsertJubsuResponse.newBuilder();
		Integer result = insertJubsuRequest(request, getHospitalCode(vertx, sessionId));
		response.setResultInsert(result != null && result > 0);
		return response.build();
	}
	
	private Integer insertJubsuRequest(NuroServiceProto.NuroOUT1001U01InsertJubsuRequest request, String hospCode){
		Out1001 out1001 = new Out1001(); 
		out1001.setSysDate(new Date());
		out1001.setSysId(request.getSysId());
		out1001.setUpdDate(new Date());
		out1001.setUpdId(request.getUpdId());
		out1001.setHospCode(hospCode);
		String seq = commonRepository.getNextVal("OUT1001_SEQ");
		Double seqNumber = CommonUtils.parseDouble(seq);
		out1001.setPkout1001(seqNumber);
		if(!StringUtils.isEmpty(request.getNaewonDate())) {
			out1001.setNaewonDate(DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
		}
		out1001.setBunho(request.getBunho());
		out1001.setGwa(request.getGwa());
		out1001.setGubun(request.getGubun());
		out1001.setDoctor(request.getDoctor());
		out1001.setChojae(request.getChojae());
		out1001.setJubsuTime(request.getJubsuTime());
		out1001.setNaewonYn(request.getNaewonYn());
		out1001.setNaewonType(request.getNaewonType());
		out1001.setSunnabYn(request.getSunnabYn());
		out1001.setJubsuGubun(request.getJubsuGubun());
		out1001.setInpTransYn(request.getInpTransYn());
		out1001.setBigo(request.getBigo());
		if(!StringUtils.isEmpty(request.getJubsuNo())) {
			out1001.setJubsuNo(new BigDecimal(request.getJubsuNo()));
		}
		if(!StringUtils.isEmpty(request.getSujinNo())) {
			out1001.setSujinNo(new BigDecimal(request.getSujinNo()));
		}
		out1001.setWonyoiOrderYn(request.getWonyoiOrderYn());
		
		out1001Repository.save(out1001);
		return 1;
	}
}
