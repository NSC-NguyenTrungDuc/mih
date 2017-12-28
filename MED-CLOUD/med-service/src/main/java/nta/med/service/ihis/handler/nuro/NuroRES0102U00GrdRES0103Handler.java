package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103Info;
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
public class NuroRES0102U00GrdRES0103Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00GrdRES0103Request, NuroServiceProto.NuroRES0102U00GrdRES0103Response>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00GrdRES0103Handler.class);
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00GrdRES0103Request request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getDate())&& DateUtil.toDate(request.getDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
		            
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00GrdRES0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00GrdRES0103Request request) throws Exception {
        NuroServiceProto.NuroRES0102U00GrdRES0103Response.Builder response = NuroServiceProto.NuroRES0102U00GrdRES0103Response.newBuilder();
        List<NuroRES0102U00GrdRES0103Info> listNuroRES0102U00GrdRES0103Info = res0103Repository.getNuroRES0102U00GrdRES0103Info(request.getHospCode(), request.getDoctor(), request.getDate());
        if (listNuroRES0102U00GrdRES0103Info != null && !listNuroRES0102U00GrdRES0103Info.isEmpty()) {
            for (NuroRES0102U00GrdRES0103Info obj : listNuroRES0102U00GrdRES0103Info) {
                NuroModelProto.NuroRES0102U00GrdRES0103Info.Builder builder = NuroModelProto.NuroRES0102U00GrdRES0103Info.newBuilder();
                if(!StringUtils.isEmpty(obj.getDoctor())) {
                	builder.setDoctor(obj.getDoctor());
                }
                if(!StringUtils.isEmpty(obj.getJinryoPreDate())) {
                	builder.setJinryoPreDate(obj.getJinryoPreDate().toString());
                }
                if(!StringUtils.isEmpty(obj.getAmStartHhmm())) {
                	builder.setAmStartHhmm(obj.getAmStartHhmm());
                }
                if(!StringUtils.isEmpty(obj.getAmEndHhmm())) {
                	builder.setAmEndHhmm(obj.getAmEndHhmm());
                }
                if(!StringUtils.isEmpty(obj.getPmStartHhmm())) {
                	builder.setPmStartHhmm(obj.getPmStartHhmm());
                }
                if(!StringUtils.isEmpty(obj.getPmEndHhmm())) {
                	builder.setPmEndHhmm(obj.getPmEndHhmm());
                }
                if(!StringUtils.isEmpty(obj.getRemark())) {
                	builder.setRemark(obj.getRemark());
                }
                if(!StringUtils.isEmpty(obj.getAmGwaRoom())) {
                	builder.setAmGwaRoom(obj.getAmGwaRoom());
                }
                if(!StringUtils.isEmpty(obj.getPmGwaRoom())) {
                	builder.setPmGwaRoom(obj.getPmGwaRoom());
                }
                response.addGridInfoList(builder);
            }
        }
		return response.build();
	}
}
