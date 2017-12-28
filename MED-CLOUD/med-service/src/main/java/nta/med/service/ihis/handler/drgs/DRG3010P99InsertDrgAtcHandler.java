package nta.med.service.ihis.handler.drgs;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.drg.DrgAtc;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.DrgAtcRepository;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99InsertDrgAtcHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99InsertDrgAtcRequest, SystemServiceProto.UpdateResponse>{
	
	@Resource
	private DrgAtcRepository drgAtcRepository;
	
	@Override
    @Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99InsertDrgAtcRequest request) throws Exception{
	
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		try{
		String hospCode = getHospitalCode(vertx, sessionId);
		Calendar cal = Calendar.getInstance();
        SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
		
		DrgAtc drgAct = new DrgAtc();
		drgAct.setSysDate(new Date());
		drgAct.setSysId(request.getUserId());
		drgAct.setUpdDate(new Date());
		drgAct.setUpdId(request.getUserId());
		if(!StringUtils.isEmpty(request.getJubsuDate())){
			drgAct.setJubsuDate(DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
		}
		drgAct.setDrgBunho(CommonUtils.parseDouble(request.getDrgBunho()));
		drgAct.setInOutGubun(request.getInOutGubun());
		if(!StringUtils.isEmpty(request.getSeq())){
			drgAct.setSeq(CommonUtils.parseDouble(request.getSeq()));
		}else{
			drgAct.setSeq(CommonUtils.parseDouble("1"));
		}
		drgAct.setInputDate(new Date());
		drgAct.setInputTime(sdf.format(cal.getTime()).toString());
		drgAct.setSendDate(null);
		drgAct.setSendTime(null);
		drgAct.setEndFlag("N");
		drgAct.setHospCode(hospCode);
		drgAtcRepository.save(drgAct);
		}catch(Exception e){
			response.setResult(false);
			return response.build();
		}
		response.setResult(true);
		return response.build();
	}
}