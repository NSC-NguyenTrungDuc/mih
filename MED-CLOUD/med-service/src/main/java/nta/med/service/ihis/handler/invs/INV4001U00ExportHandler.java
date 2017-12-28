package nta.med.service.ihis.handler.invs;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Properties;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.FileCopyUtils;
import org.vertx.java.core.Vertx;

import com.google.protobuf.ByteString;

import au.com.bytecode.opencsv.CSVWriter;
import nta.med.core.glossary.KinkiExportCsvName;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.model.ihis.invs.INV4001U00ExportInfo;
import nta.med.data.model.ihis.system.DrugKinkiInterface;
import nta.med.data.model.ihis.system.DrugKinkiMessageInfo;
import nta.med.data.model.ihis.system.ExportCsvInterface;
import nta.med.service.common.FileUtils;
import nta.med.service.ihis.handler.bass.BAS2015U00MasterDataHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00ExportRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00ExportResponse;

@Service
@Scope("prototype")
public class INV4001U00ExportHandler extends ScreenHandler<InvsServiceProto.INV4001U00ExportRequest, InvsServiceProto.INV4001U00ExportResponse> {
	
	@Resource
	private Inv4001Repository inv4001Repository;
	
	private static Properties properties = new Properties();
    private static final Log LOGGER = LogFactory.getLog(BAS2015U00MasterDataHandler.class);

    static {
        InputStream is = null;
        try {
            String configPath = System.getProperty("configPath");
            File file = new File((configPath == null ? "" : configPath + "/") + "configs.properties");
            is = new FileInputStream(file);
            properties.load(is);
        } catch (Exception ignore) {
            LOGGER.error(ignore.getMessage(), ignore);
        } finally {
            if (is != null) {
                try {
                    is.close();
                } catch (IOException e) {
                    LOGGER.error(e.getMessage(), e);
                }
            }
        }
    }

    public static String getConfigProperty(String name, String defaultValue) {
        return properties.getProperty(name, defaultValue);
    }
//	TODO not use remove after
	@Override
	@Transactional(readOnly = true)
	public INV4001U00ExportResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00ExportRequest request) throws Exception {
		InvsServiceProto.INV4001U00ExportResponse.Builder response = InvsServiceProto.INV4001U00ExportResponse.newBuilder();
		Long timeStamp = Calendar.getInstance().getTime().getTime();
		String directory = getConfigProperty("cache.path", "D:\\") + timeStamp + File.separator;
		Date fromDate = DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD);
		Date toDate =  DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD);
		List<INV4001U00ExportInfo> exportInfos = inv4001Repository.getINV4001U00ExportInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), fromDate, toDate);
		if(!CollectionUtils.isEmpty(exportInfos)){
			response = exportMsgToByteStringData(exportInfos, directory);
		}
		return response.build();
	}
	
	private InvsServiceProto.INV4001U00ExportResponse.Builder exportMsgToByteStringData(List<INV4001U00ExportInfo> exportInfos, String directory) throws IOException {
		InvsServiceProto.INV4001U00ExportResponse.Builder response = InvsServiceProto.INV4001U00ExportResponse.newBuilder();
		String filePath = directory + KinkiExportCsvName.DRUG_KINKI_MESSAGE.getValue() + ".csv";
		String fileZipPath = directory + KinkiExportCsvName.DRUG_KINKI_MESSAGE.getValue() + ".csv";
        List<ExportCsvInterface> exportData = new ArrayList<>();
        for (INV4001U00ExportInfo exportInfo : exportInfos) {
        	exportData.add(exportInfo);
        }
        response.setData(ByteString.copyFrom(FileUtils.getExportCsvData(directory, filePath, fileZipPath, exportData)));
        return response;
    } 

}
