package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001D01grdINP1001Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001D01grdINP1001Request;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001D01grdINP1001Response;

@Service
@Scope("prototype")
public class INP1001D01grdINP1001Handler extends ScreenHandler<InpsServiceProto.INP1001D01grdINP1001Request, InpsServiceProto.INP1001D01grdINP1001Response>{
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001D01grdINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001D01grdINP1001Request request) throws Exception {
		
		InpsServiceProto.INP1001D01grdINP1001Response.Builder response = InpsServiceProto.INP1001D01grdINP1001Response.newBuilder();
		
		List<INP1001D01grdINP1001Info> listInfo = inp1001Repository.getINP1001D01grdINP1001Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD), request.getHoDong(), request.getSuName());
		if (!CollectionUtils.isEmpty(listInfo)) {
			for (INP1001D01grdINP1001Info item : listInfo) {
				InpsModelProto.INP1001D01grdINP1001Info.Builder info = InpsModelProto.INP1001D01grdINP1001Info.newBuilder();
				if (item.getHoDongName() == null || "0".equals(item.getHoDongName())) {
					item.setHoDongName("");
				}
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setPkInp1001(CommonUtils.parseString(item.getPkInp1001()));
				if (item.getToiRes() != null) {
					info.setToiRes(item.getToiRes().toString());
				}
				
				response.addGrdInp1001(info);
			}
		}
		return response.build();
	}

}
