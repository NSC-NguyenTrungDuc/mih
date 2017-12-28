package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs3014Repository;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSOrderTransRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSOrderTransResponse;
import nta.med.service.ihis.proto.InpsServiceProto.INPBATCHTRANSlayOut0101Request;

@Service
@Scope("prototype")
public class INPBATCHTRANSOrderTransHandler extends ScreenHandler<InpsServiceProto.INPBATCHTRANSOrderTransRequest, InpsServiceProto.INPBATCHTRANSOrderTransResponse>{
	@Resource
	private Ifs3014Repository ifs3014Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPBATCHTRANSOrderTransResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPBATCHTRANSOrderTransRequest request) throws Exception {
		InpsServiceProto.INPBATCHTRANSOrderTransResponse.Builder response = InpsServiceProto.INPBATCHTRANSOrderTransResponse.newBuilder();
		String transGubun = request.getTransGubun();
		String ifFlag = null;
		if (StringUtils.isEmpty(transGubun))
			transGubun = "Y";
		else {
			if ("R".equals(transGubun))
				ifFlag = "10";
			else if ("N".equals(transGubun))
				ifFlag = "20";
		}
		List<Double> result = ifs3014Repository.getINPBATCHTRANSOrderTransInfo(getHospitalCode(vertx, sessionId), request.getFkinp3010(), transGubun, ifFlag);
		if (!CollectionUtils.isEmpty(result)) {
			InpsModelProto.INPBATCHTRANSOrderTransInfo.Builder info = InpsModelProto.INPBATCHTRANSOrderTransInfo.newBuilder();
			for (Double item : result) {
				info.setPkifs3014(CommonUtils.parseString(item));
				response.addOrderItem(info);
			}
		}
		return response.build();
	}

}
