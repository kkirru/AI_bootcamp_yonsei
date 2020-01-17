from s3.reader import S3Reader

# standalone process to load CSV file data from AWS S3
def main():
    r = S3Reader(
        # bucket_name="team00-test-bucket",
        # key="titanic/train.csv"
        bucket_name="team04-bucket",
        key="test/test.csv"
    )
    df = r.execute()
    print(df)


if __name__ == '__main__':
    main()
