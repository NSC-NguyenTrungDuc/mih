package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01GridInfo;
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
public class NuroOUT1101Q01GridInfoHandler extends ScreenHandler<NuroServiceProto.NuroOUT1101Q01GridInfoRequest, NuroServiceProto.NuroOUT1101Q01GridInfoResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1101Q01GridInfoHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1101Q01GridInfoRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT1101Q01GridInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1101Q01GridInfoRequest request) throws Exception {
		NuroServiceProto.NuroOUT1101Q01GridInfoResponse.Builder response = NuroServiceProto.NuroOUT1101Q01GridInfoResponse.newBuilder();
		List<NuroOUT1101Q01GridInfo> listNuroOUT1101Q01GridInfo = out1001Repository.getNuroOUT1101Q01GridInfo(getHospitalCode(vertx, sessionId), request.getGwa(), 
        		request.getDoctor(), getLanguage(vertx, sessionId), request.getNaewonDate());

        if (listNuroOUT1101Q01GridInfo != null && !listNuroOUT1101Q01GridInfo.isEmpty()) {
            for (NuroOUT1101Q01GridInfo obj : listNuroOUT1101Q01GridInfo) {
                NuroModelProto.NuroOUT1101Q01GridInfo.Builder builder = NuroModelProto.NuroOUT1101Q01GridInfo.newBuilder();
                
                if(!StringUtils.isEmpty(obj.getBunho())) {
                	builder.setBunho(obj.getBunho());
                }
                if(!StringUtils.isEmpty(obj.getSuname())) {
                	builder.setSuname(obj.getSuname());
                }
                if(!StringUtils.isEmpty(obj.getSuname2())) {
                	builder.setSuname2(obj.getSuname2());
                }
                if(!StringUtils.isEmpty(obj.getBirth())) {
                	builder.setBirth(obj.getBirth());
                }
                if(!StringUtils.isEmpty(obj.getNaewonDateJp())) {
                	builder.setNaewonDateJp(obj.getNaewonDateJp());
                }
                if(!StringUtils.isEmpty(obj.getNaewonDate())) {
                	builder.setNaewonDate(obj.getNaewonDate().toString());
                }
                if(!StringUtils.isEmpty(obj.getSujinNo())) {
                	builder.setSujinNo(obj.getSujinNo());
                }
                if(!StringUtils.isEmpty(obj.getJubsuNo())) {
                	builder.setJubsuNo(obj.getJubsuNo().toString());
                }
                if(!StringUtils.isEmpty(obj.getGwa())) {
                	builder.setGwa(obj.getGwa());
                }
                if(!StringUtils.isEmpty(obj.getGwaName())) {
                	builder.setGwaName(obj.getGwaName());
                }
                if(!StringUtils.isEmpty(obj.getDoctor())) {
                	builder.setDoctor(obj.getDoctor());
                }
                if(!StringUtils.isEmpty(obj.getDoctorName())) {
                	builder.setDoctorName(obj.getDoctorName());
                }
                if(!StringUtils.isEmpty(obj.getJubsuGubun())) {
                	builder.setJubsuGubun(obj.getJubsuGubun());
                }
                if(!StringUtils.isEmpty(obj.getGubunName())) {
                	builder.setGubunName(obj.getGubunName());
                }
                if(!StringUtils.isEmpty(obj.getJubsuTime())) {
                	builder.setJubsuTime(obj.getJubsuTime());
                }
                if(!StringUtils.isEmpty(obj.getYoyangName())) {
                	builder.setYoyangName(obj.getYoyangName());
                }
                response.addGridInfoList(builder);
            }
        }
		return response.build();
	}
}
