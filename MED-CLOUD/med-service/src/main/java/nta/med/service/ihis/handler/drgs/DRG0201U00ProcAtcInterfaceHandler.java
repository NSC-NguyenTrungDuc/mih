package nta.med.service.ihis.handler.drgs;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.drg.Drg5010Repository;
import nta.med.data.dao.medi.drg.Drg5030Repository;
import nta.med.service.CommonHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class DRG0201U00ProcAtcInterfaceHandler extends CommonHandler<DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest, DrgsServiceProto.DRG0201U00ProcAtcInterfaceResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00ProcAtcInterfaceHandler.class);
    @Resource
    private Drg5010Repository drg5010Repository;
    @Resource
    private Drg5030Repository drg5030Repository;
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }

    @Override
    public DrgsServiceProto.DRG0201U00ProcAtcInterfaceResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00ProcAtcInterfaceRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00ProcAtcInterfaceResponse.Builder response = DrgsServiceProto.DRG0201U00ProcAtcInterfaceResponse.newBuilder();
        String oErr = "";
        String hospitalCode = getHospitalCode(vertx, sessionId);
        if ("D".equalsIgnoreCase(request.getGubun())) { //DRG
            Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
            Double pkdrg5010 = drg5010Repository.callPrJihDrgDrg5010Insert(hospitalCode,
                    jubsuDate, request.getDrgBunho(), request.getIDataDubun(), request.getIInOutGubun(),
                    request.getBunho(), CommonUtils.parseInteger(request.getIFk()));
            LOG.info("pkdrg5010 = " + pkdrg5010);
            if (pkdrg5010 == null || pkdrg5010.equals(new Double(-1))) {
               // throw new ExecutionException("PR_JIH_DRG_DRG5010_INSERT result is null or -1");
                throw new ExecutionException(response.build());
            } else {
                List<String> bunryu1 = new ArrayList<String>();
                bunryu1.add("1");
                bunryu1.add("6");
                Integer updateDrg2010 = drg2010Repository.updateDRG0201U00ProcAtcInterface(pkdrg5010, hospitalCode, jubsuDate, CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho(), bunryu1);
                LOG.info("updateDRG0201U00ProcAtcInterface result is " + updateDrg2010);
                if (updateDrg2010 > 0) {
                    //rtnIfsCnt = this.makeIFSTBL("O", pkdrg5010, "Y", "D");
                    oErr = prJihDrgIfsProc(hospitalCode, "O", pkdrg5010, request.getUserId());
                    LOG.info("prJihDrgIfsProc oErr= " + oErr);
                }
            }
        } else if ("I".equalsIgnoreCase(request.getGubun())) { //INJ
            Date jubsuDate = DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
            Double pkdrg5030 = drg5030Repository.callPrJihDrgDrg5030Insert(hospitalCode,
                    jubsuDate, request.getDrgBunho(), request.getIDataDubun(), request.getIInOutGubun(),
                    request.getBunho(), CommonUtils.parseInteger(request.getIFk()));
            LOG.info("pkdrg5030 = " + pkdrg5030);
            if (pkdrg5030 == null || pkdrg5030.equals(new Double(-1))) {
               // throw new ExecutionException("PR_JIH_DRG_DRG5030_INSERT result is null or -1");
                throw new ExecutionException(response.build());
            } else {
                List<String> bunryu1 = new ArrayList<String>();
                bunryu1.add("4");
                Integer updateDrg2010 = drg2010Repository.updateDRG0201U00ProcAtcInterface(pkdrg5030, hospitalCode, jubsuDate, CommonUtils.parseDouble(request.getDrgBunho()), request.getBunho(), bunryu1);
                LOG.info("updateDRG0201U00ProcAtcInterface result is " + updateDrg2010);
                if (updateDrg2010 > 0) {
                    //rtnIfsCnt = this.makeIFSTBL("O", pkdrg5030, "Y", "I");
                    oErr = prJihDrgIfsProc(hospitalCode, "O", pkdrg5030, request.getUserId());
                    LOG.info("prJihDrgIfsProc oErr= " + oErr);
                }
            }
        }
        if (!StringUtils.isEmpty(oErr)) {
            response.setRtnIfsCnt(oErr);
        }
        response.setResult(true);
        return response.build();
    }
}
