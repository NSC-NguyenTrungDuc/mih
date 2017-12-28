package nta.med.service.ihis.handler.chts;

import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cht.Cht0115Repository;
import nta.med.data.dao.medi.cht.Cht0115SRepository;
import nta.med.data.model.ihis.chts.CHT0115Q01grdCHT0115Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class CHT0115Q01grdCHT0115Handler extends ScreenHandler<ChtsServiceProto.CHT0115Q01grdCHT0115Request, ChtsServiceProto.CHT0115Q01grdCHT0115Response> {
    private static final Log LOGGER = LogFactory.getLog(CHT0115Q01grdCHT0115Handler.class);
    @Resource
    private Cht0115SRepository cht0115SRepository;
    @Resource
    private Cht0115Repository cht0115Repository;

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0115Q01grdCHT0115Response handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0115Q01grdCHT0115Request request) throws Exception {
        ChtsServiceProto.CHT0115Q01grdCHT0115Response.Builder response = ChtsServiceProto.CHT0115Q01grdCHT0115Response.newBuilder();
        String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<CHT0115Q01grdCHT0115Info> listResult;
        if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
            listResult = cht0115SRepository.getCHT0115sQ01grdCHT0115ListItem(request.getSusikDetailGubun() + "%", startNum, CommonUtils.parseInteger(offset));
        }
        else {
            listResult = cht0115Repository.getCHT0115Q01grdCHT0115ListItem(getHospitalCode(vertx, sessionId), request.getSusikDetailGubun() + "%", startNum, CommonUtils.parseInteger(offset));
        }
        if (!CollectionUtils.isEmpty(listResult)) {
            for (CHT0115Q01grdCHT0115Info item : listResult) {
                ChtsModelProto.CHT0115Q01grdCHT0115Info.Builder info = ChtsModelProto.CHT0115Q01grdCHT0115Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListGrdInfo(info);
            }
        }
        return response.build();
    }
}