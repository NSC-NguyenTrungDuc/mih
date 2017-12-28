package nta.med.service.ihis.handler.invs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.model.ihis.invs.INV4001U00Grd4001Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00Grd4001Request;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00Grd4001Response;

@Service
@Scope("prototype")
public class INV4001U00Grd4001Handler extends ScreenHandler<InvsServiceProto.INV4001U00Grd4001Request, InvsServiceProto.INV4001U00Grd4001Response>{

	@Resource
	private Inv4001Repository inv4001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV4001U00Grd4001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00Grd4001Request request) throws Exception {
		InvsServiceProto.INV4001U00Grd4001Response.Builder response = InvsServiceProto.INV4001U00Grd4001Response.newBuilder();
		Date fromDate = DateUtil.toDate(request.getFFromDate(), DateUtil.PATTERN_YYMMDD);
		Date toDate = DateUtil.toDate(request.getFToDate(), DateUtil.PATTERN_YYMMDD);
		List<INV4001U00Grd4001Info> grdInfos = inv4001Repository.getINV4001U00Grd4001Info(getHospitalCode(vertx, sessionId), fromDate, toDate, request.getFIpgoType());
		if(!CollectionUtils.isEmpty(grdInfos)){
			for(INV4001U00Grd4001Info item : grdInfos){
				InvsModelProto.INV4001U00Grd4001Info.Builder info = InvsModelProto.INV4001U00Grd4001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLst(info);
			}
		}
		return response.build();
	}

}
